using System;   

namespace Discord.Logging
{
    /// <summary>
    /// Provides the public interface for any logging object.
    /// </summary>
    public interface ILog 
        : IDisposable
    {
        void Send(LogType type, string message);
    }
}
