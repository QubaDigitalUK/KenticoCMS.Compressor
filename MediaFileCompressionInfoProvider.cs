using System.Configuration;
using System.IO;
using System.Web;
using CMS;
using CMS.DataEngine;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using KenticoCMS.Compressor;

[assembly: RegisterCustomProvider(typeof(MediaFileCompressionInfoProvider))]

namespace KenticoCMS.Compressor
{
    public class MediaFileCompressionInfoProvider : MediaFileInfoProvider
    {
        protected override void SetMediaFileInfoInternal(
            MediaFileInfo mediaFile,
            bool saveFileToDisk,
            int userId,
            bool ensureUniqueFileName)
        {
            base.SetMediaFileInfoInternal(mediaFile, saveFileToDisk, userId, ensureUniqueFileName);

            var compressor = CompressorFactory.GetCompressor(mediaFile.FileMimeType);
			var libraryFolderPath = MediaLibraryInfoProvider.GetMediaLibraryFolderPath(mediaFile.FileLibraryID);

			if (compressor != null && libraryFolderPath != null)
            {
				
				var siteInfo = SiteContext.CurrentSite;
                var libraryInfo = MediaLibraryInfoProvider.GetMediaLibraryInfo(mediaFile.FileLibraryID);
                var filePath = Path.Combine(libraryFolderPath, mediaFile.FilePath);
                var result = compressor.Compress(filePath, true);
                mediaFile.FileSize = result.FileSizeInBytes;
                base.SetMediaFileInfoInternal(mediaFile, false, userId, ensureUniqueFileName);
            }
        }
    }
}