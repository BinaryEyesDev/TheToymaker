using System.Collections.Generic;
using TheToymaker.Components;
using TheToymaker.Entities;

namespace TheToymaker.Utilities.Testing
{
    public static class GenerateTestToy
    {
        public static void Perform()
        {
            var toy = new Toy
            {
                Name = "TestToy",
                LargeSprite = GenerateSprite.Default(),
                DamagePoints = new List<ToyDamagePoint>
                {
                    new ToyDamagePoint
                    {
                        Active = true,
                        Type = "BurstSeam",
                        Sprite = GenerateSprite.Default()
                    },
                }
            };

            var path = DataPath.Get("Toys\\TestToy.json");
            JsonData.SerializeToFile(toy, path);
        }
    }
}
