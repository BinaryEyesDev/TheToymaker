using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Components;
using TheToymaker.Utilities;
using TheToymaker.Utilities.Logging;

namespace TheToymaker
{
    /// <summary>
    ///     Provides the main entry point into the application.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            InitializeLogging.Perform();

            using (var driver = new GameDriver())
            {
                driver.IsMouseVisible = true;
                driver.Content.RootDirectory = "Content";
                driver.BackgroundColor = Color.CornflowerBlue;
                driver.Graphics = GenerateDeviceManager(driver);
                driver.SpriteBatch = new SpriteBatch(driver.GraphicsDevice);
                driver.GameCamera = GenerateGameCamera(driver);
                driver.Sprites = GenerateGameSprites(driver);

                driver.Window.Title = "The Toymaker";
                driver.Run();
            }

            DisposeLogging.Perform();
        }

        private static List<Sprite> GenerateGameSprites(GameDriver driver)
        {
            var texture = driver.Content.Load<Texture2D>("Textures/WhiteSquare_100");
            return new List<Sprite>
            {
                GenerateSprite.Default(texture)
            };
        }

        private static Camera2D GenerateGameCamera(GameDriver driver)
        {
            return new Camera2D
            {
                Transform = Transform2D.Identity,
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