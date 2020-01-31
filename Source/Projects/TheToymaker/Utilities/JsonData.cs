using System.Diagnostics;
using System.IO;
using Discord.Logging;
using Newtonsoft.Json;

namespace TheToymaker.Utilities
{
    public static class JsonData
    {
        public static T DeserializeFromFile<T>(string path)
        {
            Log.Debug($"Loading: {path}");
            string json;
            using (var reader = new StreamReader(path))
                json = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T SerializeToFile<T>(T input, string path)
        {
            Log.Debug($"Saving: {path}");
            var json = JsonConvert.SerializeObject(input, Formatting.Indented);
            using (var writer = new StreamWriter(path))
                writer.Write(json);

            return input;
        }
    }
}
