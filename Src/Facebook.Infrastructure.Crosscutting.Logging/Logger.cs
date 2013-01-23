using System;
using Facebook.Infrastructure.Ioc;
using Microsoft.Practices.Unity;

namespace Facebook.Infrastructure.Crosscutting.Logging
{
    /// <summary>
    /// Facade for writing a logs.
    /// </summary>
    public static class Logger
    {
        private static ILogWriter _writer;

        static Logger()
        {
            try
            {
                _writer = Container.Instance.Resolve<ILogWriter>();
            }
            catch (ResolutionFailedException e)
            {
                _writer = Null;
            }
        }

        /// <summary>
        /// Writes a message using the default log writer.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Log(string message)
        {
            _writer.Log(message);
        }

        /// <summary>
        /// Writes a message as a warning using the default log writer.
        /// </summary>
        /// <param name="message">The message to warn about.</param>
        public static void Warn(string message)
        {
            _writer.Warn(message);
        }

        /// <summary>
        /// This method is an alternative to inject a writer.
        /// </summary>
        /// <param name="writer"></param>
        public static void SetWriter(ILogWriter writer)
        {
            _writer.Dispose();
            _writer = writer;
        }

        private class NullLogWriter : ILogWriter
        {
            #region Implementation of IDisposable

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            /// <filterpriority>2</filterpriority>
            public void Dispose()
            {

            }

            #endregion

            #region Implementation of ILogWriter

            /// <summary>
            /// Log this message.
            /// </summary>
            /// <param name="message">The message to log.</param>
            public void Log(string message)
            {

            }

            /// <summary>
            /// Log this exception as a warm message.
            /// </summary>
            /// <param name="message">The message to warm about.</param>
            public void Warn(string message)
            {

            }

            #endregion
        }

        private static readonly ILogWriter Null = new NullLogWriter();

    }
}