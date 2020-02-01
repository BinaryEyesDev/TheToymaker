using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;
using TheToymaker.Utilities.Serialization;

namespace TheToymaker.Systems
{
    public static class RefreshToysState
    {
        public static void Perform(GameDriver driver)
        {
            if (!KeyInput.JustPressed(Keys.F3))
                return;

            if (!KeyInput.IsPressed(Keys.LeftAlt))
                driver.Toys = LoadToys.Perform(driver);
            else
                SaveToys.Perform();
        }
    }
}
