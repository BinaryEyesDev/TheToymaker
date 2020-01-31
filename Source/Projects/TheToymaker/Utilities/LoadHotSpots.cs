using System.Collections.Generic;
using TheToymaker.Components;
using TheToymaker.Data;

namespace TheToymaker.Utilities
{
    public static class LoadHotSpots
    {
        public static List<HotSpot> Perform(GameDriver driver)
        {
            var hotspot = new HotSpot
            {
                Name = "Hotspot",
                Sprite = GenerateSprite.Default(),
                DebugSprite = GenerateSprite.Default(),
                Transform = Transform2D.Identity
            };
            JsonData.SerializeToFile(hotspot, DataPath.Get("Hotspot.json"));

            var hotspots = new List<HotSpot>();
            return hotspots;
        }
    }
}
