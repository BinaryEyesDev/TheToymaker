using System.IO;
using Discord.Logging;

namespace TheToymaker.Utilities.Serialization
{
    public static class SaveHotspots
    {
        public static void Perform()
        {
            Log.Debug("Saving: Hotspots");
            var toysFolder = DataPath.Get("Hotspots");
            var hotspots = GameDriver.Instance.HotSpots;
            foreach (var hotspot in hotspots)
            {
                var path = Path.Combine(toysFolder, hotspot.Name + ".json");
                JsonData.SerializeToFile(hotspot, path);
            }
        }
    }
}
