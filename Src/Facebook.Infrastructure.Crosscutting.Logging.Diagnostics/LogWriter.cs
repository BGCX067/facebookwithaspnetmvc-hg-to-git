using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Infrastructure.Crosscutting.Logging.Diagnostics
{
    public class LogWriter : ILogWriter
    {
        #region Implementation of ILogWriter

        /// <summary>
        /// Log this message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Log(string message)
        {
            Debug.WriteLine("LOG:");
            Debug.WriteLine(message);
        }

        /// <summary>
        /// Log this exception as a warm message.
        /// </summary>
        /// <param name="message">The message to warm about.</param>
        public void Warn(string message)
        {
            Debug.WriteLine("WARN:");
            Debug.WriteLine(message);
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
