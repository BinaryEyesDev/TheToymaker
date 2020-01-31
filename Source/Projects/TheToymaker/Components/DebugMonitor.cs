using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Data;
using TheToymaker.Entities;

namespace TheToymaker.Components
{
    public static class DebugMonitor
    {
        public static void Initialize(GameDriver driver)
        {
            _driver = driver;
            _font = driver.Content.Load<SpriteFont>("Fonts/DebugFont");
            _spriteBatch = new SpriteBatch(driver.GraphicsDevice);
            _driver.Window.Title = "The Toymaker";
        }

        public static void Update(FrameTime time)
        {

        }

        public static void Draw()
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, $"TimeScale: {GameDriver.Instance.TimeScale}", new Vector2(10.0f, 10.0f), Color.White);
            _spriteBatch.DrawString(_font, $"Mouse Screen Position: {MouseInput.ScreenPosition}", new Vector2(10.0f, 30.0f), Color.White);
            _spriteBatch.DrawString(_font, $"Mouse World Position: {MouseInput.WorldPosition}", new Vector2(10.0f, 50.0f), Color.White);

            _spriteBatch.End();
        }

        private static GameDriver _driver;
        private static SpriteFont _font;
        private static SpriteBatch _spriteBatch;
    }
}
