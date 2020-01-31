using System;
using System.Collections.Generic;
using System.Globalization;

namespace Discord.Logging
{
    /// <summary>
    /// Provides the main entry into the logging system.
    /// </summary>
    public static class Log
    {
        public static void Error(string message)
        {
            Send(LogType.Error, message);
        }

        public static void Warning(string message)
        {
            Send(LogType.Warning, message);
        }

        public static void Message(string message)
        {
            Send(LogType.Info, message);
        }

        public static void Debug(string message)
        {
            Send(LogType.Debug, message);
        }

        public static void Register(ILog logger)
        {
            _loggers.Add(logger);
        }

        public static void Dispose()
        {
            foreach (var logger in _loggers)
                logger.Dispose();
         
            _loggers.Clear();
        }

        static Log()
        {
            _loggers = new List<ILog>();
        }

        private static void Send(LogType type, string message)
        {
            var timeStamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            var typeStamp = GenerateTypeStamp(type);
            var stampedMessage = $"{timeStamp}::{typeStamp}{message}";
            foreach (var logger in _loggers)
                logger.Send(type, stampedMessage);
        }

        private static string GenerateTypeStamp(LogType type)
        {
            switch (type)
            {
                case LogType.Error: return "###::";
                case LogType.Warning: return "!!!::";
                case LogType.Info: return "";
                case LogType.Debug: return "[debug]";
                default: throw new NotImplementedException("Unknown log type requested");
            }
        }

        private static readonly List<ILog> _loggers;
    }
}
