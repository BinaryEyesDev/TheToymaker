using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheToymaker
{
    public class GameDriver
        : Game
    {
        public Color BackgroundColor;
        public GraphicsDeviceManager Graphics;

        protected override void Update(GameTime time)
        {
            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
                Exit();

            base.Update(time);
        }

        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(BackgroundColor);

            base.Draw(time);
        }
    }
}
