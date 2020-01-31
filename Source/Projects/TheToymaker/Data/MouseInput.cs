using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheToymaker.Data
{
    public static class MouseInput
    {
        public static Vector2 ScreenPosition;

        public static void Update()
        {
            var mouseState = Mouse.GetState();
            ScreenPosition.X = mouseState.X;
            ScreenPosition.Y = mouseState.Y;
        }
    }
}
