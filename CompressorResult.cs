namespace KenticoCMS.Compressor
{
    public class CompressorResult
    {
        public bool IsCompressed { get; set; }
        public string FilePath { get; set; }
        public long FileSizeInBytes { get; set; }
    }
}