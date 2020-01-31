using System.IO;

namespace Discord.Logging.Data
{
    /// <summary>
    /// Responsible for logging messages to a text file.
    /// </summary>
    public class FileLog
        : ILog
    {
        public void Send(LogType type, string message)
        {
            _writer.WriteLineAsync(message);
        }

        public void Dispose()
        {
            _writer.Dispose();
        }

        public FileLog(string path)
        {
            _writer = new StreamWriter(path);
        }

        private readonly StreamWriter _writer;
    }
}
