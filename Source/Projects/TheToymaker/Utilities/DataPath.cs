using System.IO;

namespace TheToymaker.Utilities
{
    public static class DataPath
    {
        public static string Root => Path.Combine(Directory.GetCurrentDirectory(), "Data");

        public static string Get(string filename)
        {
            return Path.Combine(Root, filename);
        }
    }
}
