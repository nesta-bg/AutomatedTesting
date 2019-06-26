using NUnit.Framework;
using TestWarrior.Fundamentals;

namespace TestWarrior.UnitTests.Fundamentals
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElemenet()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            // Specific Assertion
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            //More General Assertions (a little better, especially if method returns an error message).
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain("abc").IgnoreCase);
        }
    }
}
