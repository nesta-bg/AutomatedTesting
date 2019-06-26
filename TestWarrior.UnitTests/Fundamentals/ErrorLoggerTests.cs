using NUnit.Framework;
using System;
using TestWarrior.Fundamentals;

namespace TestWarrior.UnitTests.Fundamentals
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            _logger.Log("a");

            Assert.That(_logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            //writing assertions by using a delegate
            Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);
            //Assert.That(() => _logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;
            //we are subscribing to the event before acting (_logger.Log("a"))
            //lambda expression is the event handler (in args we got some value (Guid.NewGuid()) if the event raise)
            _logger.ErrorLogged += (sender, args) => { id = args; };

            _logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
