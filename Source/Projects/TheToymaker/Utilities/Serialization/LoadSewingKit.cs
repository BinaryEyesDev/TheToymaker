using System.IO;
using Discord.Logging;
using TheToymaker.Entities;

namespace TheToymaker.Utilities.Serialization
{
    public static class LoadSewingKit
    {
        public static SewingKit Perform(GameDriver driver)
        {
            Log.Debug("Loading: Sewing Kit");
            var elementsFolder = DataPath.Get("Elements");
            var path = Path.Combine(elementsFolder, "SewingKit.json");
            return JsonData.DeserializeFromFile<SewingKit>(path);
        }
    }
}
