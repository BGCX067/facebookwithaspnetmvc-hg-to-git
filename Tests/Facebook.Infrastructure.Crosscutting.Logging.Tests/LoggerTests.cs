using Moq;
using NUnit.Framework;

namespace Facebook.Infrastructure.Crosscutting.Logging.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        [Test]
        public void Log_LoggingASimpleMessage_ShouldLogIt()
        {
            // Arrange
            var logWriterMoq = new Mock<ILogWriter>();
            Logger.SetWriter(logWriterMoq.Object);

            // Act
            Logger.Log("Some message.");

            // Assert
            logWriterMoq.Verify(writer => writer.Log("Some message."),  Times.Once());
        }

        [Test]
        public void Warn_WarningASimpleMessage_ShouldWarnIt()
        {
            // Arrange
            var logWriterMoq = new Mock<ILogWriter>();
            Logger.SetWriter(logWriterMoq.Object);

            // Act
            Logger.Warn("Some message.");

            // Assert
            logWriterMoq.Verify(writer => writer.Warn("Some message."), Times.Once());
        }
    }
}
