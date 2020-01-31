using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class ToggleFullscreen
    {
        public static void Perform(GameDriver driver)
        {
            if (!KeyInput.JustPressed(Keys.F2))
                return;

            driver.Fullscreen = !driver.Fullscreen;
            driver.Graphics.IsFullScreen = driver.Fullscreen;
            driver.Graphics.ApplyChanges();
        }
    }
}
