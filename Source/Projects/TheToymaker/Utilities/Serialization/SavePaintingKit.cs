using System.IO;
using Discord.Logging;

namespace TheToymaker.Utilities.Serialization
{
    public static class SavePaintingKit
    {
        public static void Perform()
        {
            Log.Debug("Saving: Painting Kit");
            var elementsFolder = DataPath.Get("Elements");
            var path = Path.Combine(elementsFolder, "PaintingKit.json");
            JsonData.SerializeToFile(GameDriver.Instance.PaintingKit, path);
        }
    }
}