using CheckoutKata.Application;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    [TestFixture]
    public class BasketTests
    {
        [TestCase]
        public void Can_Add_Item()
        {
            var item = new BasketItem
            {
                SKU = "A",
                UnitPrice = 10,
            };

            var basket = new Basket();
            basket.Add(item);

            Assert.AreEqual(1, basket.Count);
        }

        [TestCase]
        public void Calculates_Total()
        {
            var item1 = new BasketItem
            {
                SKU = "A",
                UnitPrice = 10,
            };

            var item2 = new BasketItem
            {
                SKU = "B",
                UnitPrice = 15,
            };

            var basket = new Basket();
            basket.Add(item1);
            basket.Add(item2);

            Assert.AreEqual(25, basket.Total);
        }

        [TestCase]
        public void Applies_3_For_40_Promotion()
        {
            var item = new BasketItem
            {
                SKU = "B",
                UnitPrice = 15,
            };

            var basket = new Basket();
            basket.Add(item);
            basket.Add(item);
            basket.Add(item);

            Assert.AreEqual(40, basket.Total);
        }

        [TestCase]
        public void Only_Applies_3_For_40_Promotion_On_Correct_Quantities()
        {
            var item = new BasketItem
            {
                SKU = "B",
                UnitPrice = 15,
            };

            var basket = new Basket();
            basket.Add(item);
            basket.Add(item);
            basket.Add(item);
            basket.Add(item);
            basket.Add(item);

            Assert.AreEqual(70, basket.Total);
        }

        [TestCase]
        public void Applies_25_Percent_Discount()
        {
            var item = new BasketItem
            {
                SKU = "D",
                UnitPrice = 55,
            };

            var basket = new Basket();
            basket.Add(item);
            basket.Add(item);

            Assert.AreEqual(96.25m, basket.Total);
        }

        [TestCase]
        public void Only_Applies_Percentage_Discount_For_Correct_Quantities()
        {
            var item = new BasketItem
            {
                SKU = "D",
                UnitPrice = 55,
            };

            var basket = new Basket();
            basket.Add(item);
            basket.Add(item);
            basket.Add(item);

            Assert.AreEqual(151.25m, basket.Total);
        }

        [TestCase]
        public void Applies_Multiple_Promotions()
        {
            var item1 = new BasketItem
            {
                SKU = "A",
                UnitPrice = 10,
            };

            var item2 = new BasketItem
            {
                SKU = "B",
                UnitPrice = 15,
            };

            var item3 = new BasketItem
            {
                SKU = "D",
                UnitPrice = 55,
            };

            var basket = new Basket();
            basket.Add(item1);
            basket.Add(item2);
            basket.Add(item2);
            basket.Add(item2);
            basket.Add(item3);
            basket.Add(item3);

            Assert.AreEqual(146.25m, basket.Total);
        }
    }
}