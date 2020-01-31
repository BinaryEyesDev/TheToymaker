using Discord.Logging;
using Discord.Logging.Data;

namespace TheToymaker.Utilities.Logging
{
    public static class InitializeLogging
    {
        public static void Perform()
        {
            Log.Register(new FileLog("game.log"));
            Log.Register(new ConsoleLog());
            Log.Message("The Toymaker");
            Log.Message("Developed By: Amir Barak");
            Log.Message("Art By: Skye Barak");
            Log.Message("Designed By: Amir & Skye Barak");
        }
    }
}
