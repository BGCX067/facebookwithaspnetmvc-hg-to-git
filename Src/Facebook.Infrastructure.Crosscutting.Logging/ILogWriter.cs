
using System;

namespace Facebook.Infrastructure.Crosscutting.Logging
{
    /// <summary>
    /// This contract defines a class used to write a log.
    /// </summary>
    public interface ILogWriter : IDisposable
    {
        /// <summary>
        /// Log this message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Log(string message);

        /// <summary>
        /// Log this exception as a warm message.
        /// </summary>
        /// <param name="message">The message to warm about.</param>
        void Warn(string message);
    }
}
