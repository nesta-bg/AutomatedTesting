using NUnit.Framework;
using TestWarrior.Fundamentals;

namespace TestWarrior.UnitTests.Fundamentals
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }
    }
}
