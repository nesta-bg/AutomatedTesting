using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestWarrior.Mocking;

namespace TestWarrior.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExistTests
    {
        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2019, 7, 6, 14, 0, 0),
                    DepartureDate = new DateTime(2019, 7, 10, 10, 0, 0),
                    Reference = "a"
                }
            }.AsQueryable());

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2019, 7, 1, 14, 0, 0),
                DepartureDate = new DateTime(2019, 7, 5, 10, 0, 0)
            }, repository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {

        }

        [Test]
        public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingReference()
        {

        }

        [Test]
        public void BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {

        }

        [Test]
        public void BookingStartsInTheMiddleOfAnExistingBookingButFinishesAfter_ReturnExistingBookingReference()
        {

        }

        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {

        }

        [Test]
        public void BookingOverlapButNewBookingIsCanceled_ReturnEmptyString()
        {

        }
    }
}
