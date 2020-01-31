using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheToymaker.Components;
using TheToymaker.Data;
using TheToymaker.Entities;
using TheToymaker.Extensions;
using TheToymaker.Systems;

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
        public TextureBank TextureBank;

        //Game
        public SpriteBatch SpriteBatch;
        public Camera2D GameCamera;
        public GameInterface GameInterface;
        public List<HotSpot> HotSpots;

        protected override void Update(GameTime time)
        {
            var elapsed = (float)time.ElapsedGameTime.TotalSeconds;
            var frameTime = new FrameTime(elapsed, TimeScale);
            
            var keyState = Keyboard.GetState();
            KeyInput.Update(keyState);
            MouseInput.Update();

            ToggleQuitGame.Perform(this);
            ToggleFullscreen.Perform(this);
            ReloadGameInterface.Perform(this);
            ReloadHotspots.Perform(this);
            UpdateHotspots.Perform(this);

            GameCamera.Update(GraphicsDevice.Viewport);
            DebugMonitor.Update(frameTime);
            base.Update(time);
        }

        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(BackgroundColor);
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, GameCamera.Transformation);

            foreach (var hotspot in HotSpots)
                SpriteBatch.DrawHotspot(hotspot);

            SpriteBatch.DrawSprite(GameInterface.TableTransform, GameInterface.TableSprite);
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
