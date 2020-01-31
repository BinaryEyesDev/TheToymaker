using Discord.Logging;

namespace TheToymaker.Utilities.Logging
{
    public static class DisposeLogging
    {
        public static void Perform()
        {
            Log.Message("Logging: Disposing");
            Log.Dispose();
        }
    }
}
