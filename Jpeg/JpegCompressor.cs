﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace KenticoCMS.Compressor.Jpeg
{
    public class JpegCompressor : ICompressor
    {
        public CompressorResult Compress(string filePath, bool overwriteOriginal = false)
        {
            var result = new CompressorResult { IsCompressed = true };
            var compressedFilePath = filePath.ReplaceLastOccurrence(".", "-mini.");
            var directoryName = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"bin");

            using (var fullSizeImg = Image.FromFile(filePath))
            {
                var jpgEncoder = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                var encoderParameters = new EncoderParameters(1) {Param = {[0] = new EncoderParameter(Encoder.Quality, (long) 70)}};
                Console.WriteLine("Lossy compressing the image.");

                fullSizeImg.Save(compressedFilePath, jpgEncoder, encoderParameters);

                var jpegTran = Path.Combine(directoryName, @"JPEG\jpegtran.exe");
                var jpegTranOptions =
                    string.Format("-optimize -progressive -copy none {0} {1}", compressedFilePath, compressedFilePath);
                var processInfo = new ProcessStartInfo(jpegTran, jpegTranOptions)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WorkingDirectory = Path.GetPathRoot(compressedFilePath)
                };
                Process process = null;
                try
                {
                    process = Process.Start(processInfo);
                }
                catch (Exception e)
                {
                }

                if (process != null)
                {
                    process.WaitForExit();
                    process.Close();
                    result.IsCompressed = false;
                }
            }

            if (overwriteOriginal)
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                if (File.Exists(compressedFilePath))
                    File.Move(compressedFilePath, filePath);

                compressedFilePath = filePath;
            }

            result.FilePath = compressedFilePath;
            result.FileSizeInBytes = new FileInfo(compressedFilePath).Length;
            return result;
        }
    }
}