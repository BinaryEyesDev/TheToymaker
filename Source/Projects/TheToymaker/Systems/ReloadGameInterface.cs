using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;
using TheToymaker.Entities;

namespace TheToymaker.Systems
{
    public static class ReloadGameInterface
    {
        public static void Perform(GameDriver driver)
        {
            if (!KeyInput.JustPressed(Keys.F4))
                return;

            driver.GameInterface = GameInterface.Initialize(driver);
        }
    }
}
