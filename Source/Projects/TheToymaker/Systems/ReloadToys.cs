using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;
using TheToymaker.Utilities;

namespace TheToymaker.Systems
{
    public static class ReloadToys
    {
        public static void Perform(GameDriver driver)
        {
            if (!KeyInput.JustPressed(Keys.F3))
                return;

            driver.Toys = LoadToys.Perform(driver);
        }
    }
}
