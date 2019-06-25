using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWarrior.Fundamentals;

namespace TestWarrior.UnitTests
{
    [TestClass]
    //NameOfTheClassWeTest+Tests
    public class ReservationTests
    {
        [TestMethod]
        //NameOfTheMethodWeTest_Scenario_ExpectedBehavior()
        public void CanBeCancelledBy_AdminCancelling_ReturnTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            // Arrange
            var reservation = new Reservation { MadeBy = new User() };

            // Act
            var result = reservation.CanBeCancelledBy(new User());

            // Assert
            Assert.IsFalse(result);
        }
    }
}
