﻿using NUnit.Framework;
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
        [Ignore("It is refactored.")]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var result = _math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("It is refactored.")]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var result = _math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("It is refactored.")]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZiro_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            // We tend to write balanced tests(not too general, not too specific). 

            // Most General
            //Assert.That(result, Is.Not.Empty);

            // More specific
            //Assert.That(result.Count(), Is.EqualTo(3));

            // Most specific 
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 })); //It doesn't care about the order.

            //Another usefull assertions
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);
        }

        [Test]
        public void GetOddNumbers_LimitIsZiro_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(0);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetOddNumbers_LimitIsLessThanZiro_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(-5);

            Assert.That(result, Is.Empty);
        }
    }
}
