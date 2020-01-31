using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class ToggleEditingMode
    {
        public static void Perform(GameDriver driver)
        {
            if (!KeyInput.JustPressed(Keys.E))
                return;

            if (!KeyInput.IsPressed(Keys.LeftAlt))
                return;

            driver.EditingMode = !driver.EditingMode;
        }
    }
}
