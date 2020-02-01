using System.IO;
using Discord.Logging;
using TheToymaker.Entities;

namespace TheToymaker.Utilities.Serialization
{
    public static class LoadPaintingKit
    {
        public static PaintingKit Perform(GameDriver driver)
        {
            Log.Debug("Loading: Painting Kit");
            var elementsFolder = DataPath.Get("Elements");
            var path = Path.Combine(elementsFolder, "PaintingKit.json");
            return JsonData.DeserializeFromFile<PaintingKit>(path);
        }
    }
}
