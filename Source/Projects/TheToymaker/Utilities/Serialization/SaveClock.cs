using System.IO;
using Discord.Logging;

namespace TheToymaker.Utilities.Serialization
{
    public static class SaveClock
    {
        public static void Perform()
        {
            Log.Debug("Saving: Desk Clock");
            var elementsFolder = DataPath.Get("Elements");
            var path = Path.Combine(elementsFolder, "DeskClock.json");
            JsonData.SerializeToFile(GameDriver.Instance.Clock, path);
        }
    }
}
