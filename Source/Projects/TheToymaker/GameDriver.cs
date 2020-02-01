using System.Collections.Generic;
using System.Linq;
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
        public bool EditingMode = false;
        public bool ShowHotspotBox = true;
        public float TimeScale;
        public Color BackgroundColor;
        public GraphicsDeviceManager Graphics;
        public TextureBank TextureBank;

        //Game
        public SpriteBatch SpriteBatch;
        public Camera2D GameCamera;
        public GameInterface GameInterface;
        public List<HotSpot> HotSpots;
        public List<Toy> Toys;
        public DeskClock Clock;

        protected override void Update(GameTime time)
        {
            var elapsed = (float)time.ElapsedGameTime.TotalSeconds;
            var frameTime = new FrameTime(elapsed, TimeScale);
            
            var keyState = Keyboard.GetState();
            KeyInput.Update(keyState);
            MouseInput.Update();

            ToggleHotspotBoxes.Perform(this);
            ToggleQuitGame.Perform(this);
            ToggleFullscreen.Perform(this);
            ToggleEditingMode.Perform(this);
            ReloadGameInterface.Perform(this);
            RefreshHotspotsState.Perform(this);
            RefreshToysState.Perform(this);
            RefreshDeskClockState.Perform(this);
            EditingMouseGrab.Perform(this);
            UpdateHotspots.Perform(this);

            Clock.Update(frameTime);
            GameCamera.Update(GraphicsDevice.Viewport);
            DebugMonitor.Update(frameTime);
            base.Update(time);
        }

        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(BackgroundColor);
            SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, null, null, null, null, GameCamera.Transformation);

            foreach (var hotspot in HotSpots)
                SpriteBatch.DrawHotspot(hotspot);

            foreach (var toy in Toys.Where(element => element.Active))
                SpriteBatch.DrawToy(toy);

            SpriteBatch.DrawSprite(GameInterface.TableTransform, GameInterface.TableSprite);
            SpriteBatch.DrawSprite(GameInterface.ToyLocationOnTable, GameInterface.Square);
            SpriteBatch.DrawSprite(GameInterface.ToyLocationInFront, GameInterface.Square);
            SpriteBatch.DrawSprite(Clock.HourHandTransform, Clock.HourHandSprite);
            SpriteBatch.DrawSprite(Clock.MinuteHandTransform, Clock.MinuteHandSprite);
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
