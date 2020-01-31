using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheToymaker.Data
{
    public static class MouseInput
    {
        public static Vector2 ScreenPosition;
        public static Vector2 WorldPosition;

        public static void Update()
        {
            var mouseState = Mouse.GetState();
            ScreenPosition.X = mouseState.X;
            ScreenPosition.Y = mouseState.Y;

            var camera = GameDriver.Instance.GameCamera;
            var invertTransformation = Matrix.Invert(camera.Transformation);
            WorldPosition = Vector2.Transform(ScreenPosition, invertTransformation);
        }
    }
}
