using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheToymaker.Utilities
{
    public static class CalculateKeyboardDirection
    {
        public static Vector2 Perform(KeyboardState keyState)
        {
            var direction = new Vector2(0.0f, 0.0f);
            direction.X += keyState.IsKeyDown(Keys.Left) ? -1.0f : 0.0f;
            direction.X += keyState.IsKeyDown(Keys.Right) ? +1.0f : 0.0f;
            direction.Y += keyState.IsKeyDown(Keys.Down) ? -1.0f : 0.0f;
            direction.Y += keyState.IsKeyDown(Keys.Up) ? +1.0f : 0.0f;

            return direction;
        }
    }
}
