using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheToymaker.Utilities.Logging;

namespace TheToymaker
{
    /// <summary>
    ///     Provides the main entry point into the application.
    /// </summary>
    public static class Application
    {
        public static void Main(string[] args)
        {
            InitializeLogging.Perform();

            using (var driver = new GameDriver())
            {
                driver.BackgroundColor = Color.CornflowerBlue;
                driver.Graphics = GenerateDeviceManager(driver);

                driver.Window.Title = "The Toymaker";
                driver.Run();
            }

            DisposeLogging.Perform();
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

            return graphics;
        }
    }
}