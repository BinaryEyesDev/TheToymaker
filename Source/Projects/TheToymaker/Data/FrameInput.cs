using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace TheToymaker.Data
{
    public static class KeyInput
    {
        public static bool IsReleased(Keys keyCode)
        {
            return !_currentlyPressed.Contains(keyCode);
        }

        public static bool WasReleased(Keys keyCode)
        {
            return _previouslyPressed.Contains(keyCode) && !_currentlyPressed.Contains(keyCode);
        }

        public static bool IsPressed(Keys keyCode)
        {
            return _currentlyPressed.Contains(keyCode);
        }

        public static bool JustPressed(Keys keyCode)
        {
            return !_previouslyPressed.Contains(keyCode) && _currentlyPressed.Contains(keyCode);
        }

        public static void Update(KeyboardState keyState)
        {
            _previouslyPressed = _currentlyPressed;
            _currentlyPressed = keyState.GetPressedKeys().ToList();
        }

        static KeyInput()
        {
            _currentlyPressed = new List<Keys>();
            _previouslyPressed = new List<Keys>();
        }

        private static List<Keys> _currentlyPressed;
        private static List<Keys> _previouslyPressed;
    }
}
