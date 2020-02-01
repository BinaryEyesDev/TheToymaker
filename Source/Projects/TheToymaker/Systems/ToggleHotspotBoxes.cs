using Microsoft.Xna.Framework.Input;
using TheToymaker.Data;

namespace TheToymaker.Systems
{
    public static class ToggleHotspotBoxes
    {
        public static void Perform(GameDriver driver)
        {
            if (!KeyInput.JustPressed(Keys.H))
                return;

            if (!KeyInput.IsPressed(Keys.LeftAlt))
                return;

            GameDriver.Instance.ShowHotspotBox = !GameDriver.Instance.ShowHotspotBox;
        }
    }
}
