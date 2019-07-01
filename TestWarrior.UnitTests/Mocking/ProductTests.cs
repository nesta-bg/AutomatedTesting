using NUnit.Framework;
using TestWarrior.Mocking;

namespace TestWarrior.UnitTests.Mocking
{
    [TestFixture]
    class ProductTests
    {
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            var product = new Product { ListPrice = 100 };

            var result = product.GetPrice(new Customer { IsGold = true });

            Assert.That(result, Is.EqualTo(70));
        }
    }
}
