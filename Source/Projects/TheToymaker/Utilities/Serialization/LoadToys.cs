using System.Collections.Generic;
using System.IO;
using Discord.Logging;
using TheToymaker.Entities;

namespace TheToymaker.Utilities.Serialization
{
    public static class LoadToys
    {
        public static List<Toy> Perform(GameDriver driver)
        {
            Log.Debug("Loading: Toys");
            var toysFolder = DataPath.Get("Toys");
            var toyFiles = Directory.GetFiles(toysFolder);

            var toys = new List<Toy>();
            foreach (var toyFile in toyFiles)
            {
                var toy = JsonData.DeserializeFromFile<Toy>(toyFile);
                toy.Name = Path.GetFileNameWithoutExtension(toyFile);
                toys.Add(toy);
            }

            return toys;
        }
    }
}
