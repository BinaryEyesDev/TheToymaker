using System;

namespace Discord.Logging.Data
{
    /// <summary>
    /// Responsible for sending messages to the console stream.
    /// </summary>
    public class ConsoleLog
        : ILog
    {
        public void Send(LogType type, string message)
        {
            Console.WriteLine(message);
        }

        public void Dispose()
        {

        }
    }
}
