using System.Collections.Generic;
using System.IO;
using System.Linq;
using Discord.Logging;
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
            var textures = new List<Texture2D>();
            var textureFiles = FindTextureFiles();
            foreach (var textureFile in textureFiles)
            {
                Log.Message($"Loading: Texture: {textureFile}");
                var filename = Path.GetFileNameWithoutExtension(textureFile);
                if (string.IsNullOrEmpty(filename))
                    continue;

                var localPath = Path.Combine("Textures", filename);
                var texture = driver.Content.Load<Texture2D>(localPath);
                if (texture == null)
                    Log.Error($"Failed: Loading Texture: {textureFile}");

                Log.Message($"Loaded: {texture?.Name}");
                textures.Add(texture);
            }

            var sprites = new List<Sprite>();
            foreach (var texture in textures)
            {
                var sprite = GenerateSprite.Default(texture);
                sprites.Add(sprite);
            }

            return sprites;
        }

        private static List<string> FindTextureFiles()
        {
            var directory = Directory.GetCurrentDirectory();
            var contentFolder = Path.Combine(directory, "Content");
            var texturesFolder = Path.Combine(contentFolder, "Textures");
            return Directory.GetFiles(texturesFolder).ToList();
        }

        private static Camera2D GenerateGameCamera(GameDriver driver)
        {
            var viewport = driver.GraphicsDevice.Viewport;
            var targetResolution = new Vector2(1920.0f, 1080.0f);
            var currentResolution = new Vector2(viewport.Width, viewport.Height);
            var ratio = new Vector2(currentResolution.X/ targetResolution.X, currentResolution.Y/ targetResolution.Y);

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