using System.Reflection;
using log4net;

namespace Facebook.Infrastructure.Crosscutting.Logging.Log4net
{
    /// <summary>
    /// A concrete implementation of a log writer.
    /// </summary>
    public sealed class LogWriter : ILogWriter
    {
        // Analize the parameters passed to GetLogger method bettter.
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Implementation of ILogWriter

        /// <summary>
        /// Log this message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Log(string message)
        {
            _log.Info(message);
        }

        /// <summary>
        /// Log this exception as a warm message.
        /// </summary>
        /// <param name="message">The message to warm about.</param>
        public void Warn(string message)
        {
            _log.Warn(message);
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            
        }

        #endregion
    }
}
