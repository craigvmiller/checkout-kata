using CheckoutKata.Application;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class BasketTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Can_Add_Item()
        {
            var item = new BasketItem
            {
                SKU = "A",
                UnitPrice = 10,
            };

            var basket = new Basket();
            basket.Add(item);

            Assert.AreEqual(1, basket.Items.Count);
        }
    }
}