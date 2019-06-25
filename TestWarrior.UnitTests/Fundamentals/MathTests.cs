using NUnit.Framework;
using TestWarrior.Fundamentals;

namespace TestWarrior.UnitTests.Fundamentals
{
    [TestFixture] 
    public class MathTests
    {
        private Math _math;

        //SetUp -before each test
        //TearDown -after each test

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        //One execution path
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        //Two execution paths
        //thing about a Max method as a black box that takes two arguments, dont watch the implementation of Max method
        //the same is for all test we are writing
       
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
