using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Data;

namespace TheToymaker.Components
{
    public static class DebugMonitor
    {
        public static void Initialize(GameDriver driver)
        {
            driver.Window.Title = "The Toymaker";
            _font = driver.Content.Load<SpriteFont>("Fonts/DebugFont");
            _spriteBatch = new SpriteBatch(driver.GraphicsDevice);
        }

        public static void Update(FrameTime time)
        {

        }

        public static void Draw()
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, $"TimeScale: {GameDriver.Instance.TimeScale}", new Vector2(10.0f, 10.0f), Color.White);

            _spriteBatch.End();
        }

        private static SpriteFont _font;
        private static SpriteBatch _spriteBatch;
    }
}
