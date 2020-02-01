using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;
using TheToymaker.Utilities.Serialization;

namespace TheToymaker.Systems
{
    public static class RefreshBackgroundElements
    {
        public static void Perform(GameDriver driver)
        {
            if (!KeyInput.JustPressed(Keys.F5))
                return;

            if (!KeyInput.IsPressed(Keys.LeftAlt))
            {
                driver.Clock = LoadClock.Perform(driver);
                driver.SewingKit = LoadSewingKit.Perform(driver);
            }
            else
            {
                SaveClock.Perform();
                SaveSewingKit.Perform();
            }
        }
    }
}
