using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;
using TheToymaker.Utilities;

namespace TheToymaker.Systems
{
    public static class ReloadHotspots
    {
        public static void Perform(GameDriver driver)
        {
            if (!KeyInput.JustPressed(Keys.F3))
                return;

            driver.HotSpots = LoadHotSpots.Perform(driver);
        }
    }
}
