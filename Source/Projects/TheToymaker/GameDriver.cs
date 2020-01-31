using System.Collections.Generic;
using Discord.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheToymaker.Components;

namespace TheToymaker
{
    public class GameDriver
        : Game
    {
        public Color BackgroundColor;
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;
        public Camera2D GameCamera;
        public List<Sprite> Sprites;

        protected override void Update(GameTime time)
        {
            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
                Exit();

            var elapsed = (float) time.ElapsedGameTime.TotalSeconds;
            var keyboardMovementDirection = CalculateMovementDirection(keyState);
            var velocity = keyboardMovementDirection*100.0f;
            GameCamera.Transform.Position += velocity*elapsed;
            GameCamera.Update(GraphicsDevice.Viewport);
            base.Update(time);
        }

        private static Vector2 CalculateMovementDirection(KeyboardState keyState)
        {
            var direction = new Vector2(0.0f, 0.0f);
            direction.X += keyState.IsKeyDown(Keys.Left) ? -1.0f : 0.0f;
            direction.X += keyState.IsKeyDown(Keys.Right) ? +1.0f : 0.0f;
            direction.Y += keyState.IsKeyDown(Keys.Down) ? -1.0f : 0.0f;
            direction.Y += keyState.IsKeyDown(Keys.Up) ? +1.0f : 0.0f;

            return direction;
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

            base.Draw(time);
        }
    }
}
