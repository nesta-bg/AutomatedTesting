using NUnit.Framework;
using System;
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

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();

            //writing assertions by using a delegate
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            //Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            //we are subscribing to the event before acting (logger.Log("a"))
            //lambda expression is the event handler (in args we got some value (Guid.NewGuid()) if the event raise)
            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
