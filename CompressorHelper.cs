namespace KenticoCMS.Compressor
{
    public static class CompressorHelper
    {
        public static string ReplaceLastOccurrence(this string source, string find, string replace)
        {
            int place = source.LastIndexOf(find);

            return place == -1 
                ? string.Empty 
                : source.Remove(place, find.Length).Insert(place, replace);
        }
    }
}
