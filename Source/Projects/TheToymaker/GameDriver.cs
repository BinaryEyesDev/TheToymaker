using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheToymaker.Components;
using TheToymaker.Data;
using TheToymaker.Entities;
using TheToymaker.Events;
using TheToymaker.Extensions;
using TheToymaker.Systems;
using TheToymaker.Utilities;

namespace TheToymaker
{
    public class GameDriver
        : Game
    {
        public static GameDriver Instance { get; private set; }
        public event EventHandler<GameStateChanged> StateChanged; 

        public bool Fullscreen = false;
        public bool EditingMode = false;
        public bool ShowHotspotBox = false;
        public float TimeScale;
        public Color BackgroundColor;
        public GraphicsDeviceManager Graphics;
        public TextureBank TextureBank;

        //Game
        public GameState State;
        public SpriteBatch SpriteBatch;
        public Camera2D GameCamera;
        public GameInterface GameInterface;
        public ShopBackground ShopBackground;

        //Gameplay
        public Money Money;
        public List<Hotspot> HotSpots;
        public List<Toy> Toys;
        public Toy CurrentToy;
        public List<Toy> WaitingToyLine { get; set; }

        //Background Elements
        public DeskClock Clock;
        public SewingKit SewingKit;
        public PaintingKit PaintingKit;
        public Customer Customer;

        public GameDriver ChangeState(GameState next)
        {
            var previous = State;
            State = next;
            StateChanged?.Invoke(this, new GameStateChanged(previous, next));
            return this;
        }

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
            RefreshBackgroundElements.Perform(this);
            EditingMouseGrab.Perform(this);

            if (State == GameState.WaitingForClient)
            {
                GenerateNewCustomer.Perform(this, frameTime);
            }

            if (State == GameState.FixingToy)
            {
                HandleHotspotInteraction.Perform(this);
                ResolveCurrentToy.Perform(this);
            }

            if (State == GameState.ClientPayment)
            {
                HandlePaymentProcess.Perform(this);
            }

            if (State == GameState.ClientLeaving)
            {
                GenerateNewCustomer.WaitTime = GetRandom.Float(1.0f, 2.0f);
                ChangeState(GameState.WaitingForClient);
            }

            Clock.Update(frameTime);
            GameCamera.Update(GraphicsDevice.Viewport);
            DebugMonitor.Update(frameTime);
            base.Update(time);
        }

        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(BackgroundColor);
            SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null, null, GameCamera.Transformation);
            SpriteBatch.DrawSprite(ShopBackground.Transform, ShopBackground.Sprite);

            foreach (var hotspot in HotSpots)
                SpriteBatch.DrawHotspot(hotspot);

            foreach (var toy in Toys.Where(element => element.Active))
                SpriteBatch.DrawToy(toy);

            if (EditingMode)
            {
                SpriteBatch.DrawSprite(GameInterface.ToyLocationOnTable, GameInterface.Square);
                SpriteBatch.DrawSprite(GameInterface.ToyLocationInFront, GameInterface.Square);
                SpriteBatch.DrawSprite(GameInterface.CustomerLocation, GameInterface.Square);
                SpriteBatch.DrawSprite(GameInterface.SpeechLocation, GameInterface.Square);
                SpriteBatch.DrawSprite(GameInterface.MoneyLocation, GameInterface.Square);
            }

            SpriteBatch.DrawMoney(Money);
            SpriteBatch.DrawSprite(GameInterface.TableTransform, GameInterface.TableSprite);
            SpriteBatch.DrawSprite(Clock.HourHandTransform, Clock.HourHandSprite);
            SpriteBatch.DrawSprite(Clock.MinuteHandTransform, Clock.MinuteHandSprite);
            SpriteBatch.DrawSprite(SewingKit.Transform, SewingKit.Sprite);
            SpriteBatch.DrawSprite(PaintingKit.Transform, PaintingKit.Sprite);

            if (State != GameState.WaitingForClient && State != GameState.ClientLeaving)
                SpriteBatch.DrawSprite(Customer.Transform, Customer.Sprite);

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
