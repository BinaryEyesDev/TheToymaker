using System.Collections.Generic;
using System.IO;
using TheToymaker.Entities;

namespace TheToymaker.Utilities
{
    public static class LoadToys
    {
        public static List<Toy> Perform(GameDriver driver)
        {
            var toysFolder = DataPath.Get("Toys");
            var toyFiles = Directory.GetFiles(toysFolder);

            var toys = new List<Toy>();
            foreach (var toyFile in toyFiles)
            {
                var toy = JsonData.DeserializeFromFile<Toy>(toyFile);
                toys.Add(toy);
            }

            return toys;
        }
    }
}
