using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheToymaker.Components;
using TheToymaker.Data;

namespace TheToymaker
{
    public class GameDriver
        : Game
    {
        public static GameDriver Instance { get; private set; }

        public bool Fullscreen = false;
        public float TimeScale;
        public Color BackgroundColor;
        public GraphicsDeviceManager Graphics;

        //Game
        public SpriteBatch SpriteBatch;
        public Camera2D GameCamera;
        public List<Sprite> Sprites;

        protected override void Update(GameTime time)
        {
            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
                Exit();

            var elapsed = (float) time.ElapsedGameTime.TotalSeconds;
            var frameTime = new FrameTime(elapsed, TimeScale);

            GameCamera.Update(GraphicsDevice.Viewport);
            DebugMonitor.Update(frameTime);
            base.Update(time);
        }

        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(BackgroundColor);

            SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, GameCamera.Transformation);
            foreach (var sprite in Sprites)
            {
                SpriteBatch.Draw(
                    sprite.Image,
                    sprite.Transform.Position,
                    sprite.Frame,
                    sprite.Tint,
                    sprite.Transform.Angle,
                    sprite.Pivot,
                    sprite.Transform.Scale,
                    sprite.Effects,
                    sprite.Layer);
            }

            SpriteBatch.End();
            DebugMonitor.Draw();
            base.Draw(time);
        }

        public GameDriver()
        {
            Instance = this;
        }
    }
}
