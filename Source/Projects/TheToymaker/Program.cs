﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;
using TheToymaker.Data;
using TheToymaker.Entities;
using TheToymaker.Utilities;
using TheToymaker.Utilities.Logging;
using TheToymaker.Utilities.Serialization;

namespace TheToymaker
{
    /// <summary>
    /// Provides the main entry point into the application.
    /// </summary>
    public static class Program
    {
        public static readonly Vector2 TargetResolution = new Vector2(1920.0f, 1080.0f);

        public static void Main(string[] args)
        {
            InitializeLogging.Perform();
            
            using (var driver = new GameDriver())
            {
                driver.ChangeState(GameState.Initializing);
                driver.IsMouseVisible = true;
                driver.Content.RootDirectory = "Content";
                driver.BackgroundColor = Color.DarkGray;
                driver.TimeScale = 1.0f;
                driver.Graphics = GenerateDeviceManager(driver);
                driver.TextureBank = new TextureBank().Initialize(driver);

                driver.SpriteBatch = new SpriteBatch(driver.GraphicsDevice);
                driver.GameCamera = GenerateGameCamera(driver);
                driver.GameInterface = GameInterface.Initialize(driver);
                driver.ShopBackground = ShopBackground.Initialize(driver);
                driver.Phone = PhoneMachine.Initialize(driver);
                driver.Money = Money.Initialize(driver);
                driver.HotSpots = LoadHotSpots.Perform(driver);
                driver.Toys = LoadToys.Perform(driver);
                driver.Clock = DeskClock.Initialize(driver);
                driver.SewingKit = SewingKit.Initialize(driver);
                driver.PaintingKit = PaintingKit.Initialize(driver);
                driver.Customer = Customer.Initialize(driver);

                DebugMonitor.Initialize(driver);

                driver.ChangeState(GameState.SplashScreen).ChangeState(GameState.WaitingForClient);
                driver.Run();
            }

            DisposeLogging.Perform();
        }

        private static Camera2D GenerateGameCamera(GameDriver driver)
        {
            var viewport = driver.GraphicsDevice.Viewport;
            var (width, height) = new Vector2(viewport.Width, viewport.Height);
            var ratio = new Vector2(width/TargetResolution.X, height/TargetResolution.Y);

            var transform = Transform2D.Identity;
            transform.Scale = ratio;
            return new Camera2D
            {
                Transform = transform,
                Transformation = Matrix.Identity,
            };
        }

        private static GraphicsDeviceManager GenerateDeviceManager(GameDriver driver)
        {
            var graphics = new GraphicsDeviceManager(driver)
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720,
                GraphicsProfile = GraphicsProfile.Reach,
                SynchronizeWithVerticalRetrace = false,
                IsFullScreen = false,
                PreferMultiSampling = true
            };

            graphics.ApplyChanges();
            return graphics;
        }
    }
}