namespace KenticoCMS.Compressor
{
    public interface ICompressor
    {
        CompressorResult Compress(string filePath, bool overwriteOriginal = false);
    }
}