using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;
using TheToymaker.Utilities;
using TheToymaker.Utilities.Serialization;

namespace TheToymaker.Systems
{
    public static class RefreshHotspotsState
    {
        public static void Perform(GameDriver driver)
        {
            if (!KeyInput.JustPressed(Keys.F2))
                return;

            if (!KeyInput.IsPressed(Keys.LeftAlt))
                driver.HotSpots = LoadHotSpots.Perform(driver);
            else
                SaveHotspots.Perform();
        }
    }
}
