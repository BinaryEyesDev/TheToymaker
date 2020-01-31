using TheToymaker.Components;
using TheToymaker.Data;

namespace TheToymaker.Utilities.Testing
{
    public static class GenerateTestHotspot
    {
        public static void Perform()
        {
            var hotspot = new HotSpot
            {
                Name = "Hotspot",
                Sprite = GenerateSprite.Default(),
                DebugSprite = GenerateSprite.Default(),
                Transform = Transform2D.Identity
            };

            JsonData.SerializeToFile(hotspot, DataPath.Get("Hotspot.json"));
        }
    }
}
