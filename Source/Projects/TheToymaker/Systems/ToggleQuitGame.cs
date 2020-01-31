using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class ToggleQuitGame
    {
        public static void Perform(GameDriver driver)
        {
            if (KeyInput.JustPressed(Keys.Escape))
                driver.Exit();
        }
    }
}
