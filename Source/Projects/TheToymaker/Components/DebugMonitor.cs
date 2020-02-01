using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Data;

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
            var editModeState = GameDriver.Instance.EditingMode ? "On" : "Off";
            var showHotspots = GameDriver.Instance.ShowHotspotBox ? "Visible" : "Hidden";
            var minuteAngle = (int)GameDriver.Instance.Clock.MinuteHandTransform.Angle;
            var minute = minuteAngle%6;

            _spriteBatch.Begin();
            //_spriteBatch.DrawString(_font, $"TimeScale: {GameDriver.Instance.TimeScale}", new Vector2(10.0f, 10.0f), Color.White);
            //_spriteBatch.DrawString(_font, $"Mouse Screen Position: {MouseInput.ScreenPosition}", new Vector2(10.0f, 30.0f), Color.White);
            //_spriteBatch.DrawString(_font, $"Mouse World Position: {MouseInput.WorldPosition}", new Vector2(10.0f, 50.0f), Color.White);
            _spriteBatch.DrawString(_font, $"Editing Mode: {editModeState}", new Vector2(10.0f, 5.0f), Color.White);
            _spriteBatch.DrawString(_font, $"Hotspot Boxes: {showHotspots}", new Vector2(10.0f, 25.0f), Color.White);
            _spriteBatch.DrawString(_font, $"Hour: {GameDriver.Instance.Clock.Hour}", new Vector2(10.0f, 45.0f), Color.White);
            _spriteBatch.DrawString(_font, $"Minute: {GameDriver.Instance.Clock.Minute}", new Vector2(10.0f, 65.0f), Color.White);

            _spriteBatch.End();
        }

        private static GameDriver _driver;
        private static SpriteFont _font;
        private static SpriteBatch _spriteBatch;
    }
}
