using System.Collections.Generic;
using System.IO;
using Discord.Logging;
using TheToymaker.Data;

namespace TheToymaker.Utilities
{
    public static class LoadHotSpots
    {
        public static List<HotSpot> Perform(GameDriver driver)
        {
            var hotspotFolder = DataPath.Get("Hotspots");
            var hotspotFiles = Directory.GetFiles(hotspotFolder);
            Log.Message($"Found {hotspotFiles.Length} Hotspot Files");

            var hotspots = new List<HotSpot>();
            foreach (var hotspotFile in hotspotFiles)
            {
                var hotspot = JsonData.DeserializeFromFile<HotSpot>(hotspotFile);
                hotspots.Add(hotspot);
            }

            return hotspots;
        }
    }
}
