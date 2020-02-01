using System.IO;
using Discord.Logging;
using TheToymaker.Entities;

namespace TheToymaker.Utilities.Serialization
{
    public static class LoadClock
    {
        public static DeskClock Perform(GameDriver driver)
        {
            Log.Debug("Loading: Desk Clock");
            var elementsFolder = DataPath.Get("Elements");
            var path = Path.Combine(elementsFolder, "DeskClock.json");
            return JsonData.DeserializeFromFile<DeskClock>(path);
        }
    }
}
