using System.Collections.Generic;
using System.IO;
using Discord.Logging;
using TheToymaker.Data;

namespace TheToymaker.Utilities
{
    public static class LoadHotSpots
    {
        public static List<Hotspot> Perform(GameDriver driver)
        {
            var hotspotFolder = DataPath.Get("Hotspots");
            var hotspotFiles = Directory.GetFiles(hotspotFolder);
            Log.Message($"Found {hotspotFiles.Length} Hotspot Files");

            var hotspots = new List<Hotspot>();
            foreach (var hotspotFile in hotspotFiles)
            {
                var hotspot = JsonData.DeserializeFromFile<Hotspot>(hotspotFile);
                hotspot.Name = Path.GetFileNameWithoutExtension(hotspotFile);
                hotspots.Add(hotspot);
            }

            return hotspots;
        }
    }
}
