using System.IO;
using Discord.Logging;

namespace TheToymaker.Utilities.Serialization
{
    public static class SaveSewingKit
    {
        public static void Perform()
        {
            Log.Debug("Saving: Sewing Kit");
            var elementsFolder = DataPath.Get("Elements");
            var path = Path.Combine(elementsFolder, "SewingKit.json");
            JsonData.SerializeToFile(GameDriver.Instance.SewingKit, path);
        } 
    }
}
