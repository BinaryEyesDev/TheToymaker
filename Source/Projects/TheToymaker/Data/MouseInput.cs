using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheToymaker.Data
{
    public static class MouseInput
    {
        public static Vector2 ScreenPosition => _screenPosition;
        public static Vector2 WorldPosition => _worldPosition;
        public static bool LeftButtonJustPressed => _previousLeftButton == ButtonState.Released && _leftButton == ButtonState.Pressed;
        public static bool LeftButtonPressed => _leftButton == ButtonState.Pressed;
        public static bool LeftButtonReleased => _leftButton == ButtonState.Released;

        public static void Update()
        {
            var mouseState = Mouse.GetState();
            _screenPosition.X = mouseState.X;
            _screenPosition.Y = mouseState.Y;

            var camera = GameDriver.Instance.GameCamera;
            var invertTransformation = Matrix.Invert(camera.Transformation);
            _worldPosition = Vector2.Transform(_screenPosition, invertTransformation);

            _previousLeftButton = _leftButton;
            _leftButton = mouseState.LeftButton;
        }

        private static ButtonState _previousLeftButton;
        private static ButtonState _leftButton;
        private static Vector2 _worldPosition;
        private static Vector2 _screenPosition;
    }
}
