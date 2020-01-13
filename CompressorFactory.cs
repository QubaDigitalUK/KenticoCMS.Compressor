using KenticoCMS.Compressor.Jpeg;
using KenticoCMS.Compressor.PNG;

namespace KenticoCMS.Compressor
{
    public static class CompressorFactory
    {
        public static ICompressor GetCompressor(string mimeType)
        {
            switch (mimeType)
            {
                case "image/jpeg":
                {
                    return new JpegCompressor();
                }
                case "image/png":
                {
                    return new PngCompressor();
                }
            }
            return null;
        }
    }
}