using System.IO;
using Discord.Logging;

namespace TheToymaker.Utilities.Serialization
{
    public static class SaveToys
    {
        public static void Perform()
        {
            Log.Debug("Saving: Toys");
            var toysFolder = DataPath.Get("Toys");
            var toys = GameDriver.Instance.Toys;
            foreach (var toy in toys)
            {
                var path = Path.Combine(toysFolder, toy.Name + ".json");
                JsonData.SerializeToFile(toy, path);
            }
        }
    }
}
