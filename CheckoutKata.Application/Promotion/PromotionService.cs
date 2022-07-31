using CheckoutKata.Application.Basket;

namespace CheckoutKata.Application.Promotion
{
    public class PromotionService
    {
        private ICollection<Promotion> _promotions;

        public PromotionService()
        {
            _promotions = new List<Promotion>()
            {
                new Promotion
                {
                    ItemSKU = "B",
                    QuantityRequired = 3,
                    PromotionType = PromotionType.PriceOverride,
                    Amount = 40,
                },
                new Promotion
                {
                    ItemSKU = "D",
                    QuantityRequired = 2,
                    PromotionType = PromotionType.DiscountPercentage,
                    Amount = 25,
                }
            };
        }

        public ICollection<Promotion> GetRelevantPromotions(BasketItemSummary item)
        {
            return _promotions.Where(p => p.ItemSKU == item.Item.SKU && item.Quantity >= p.QuantityRequired).ToList();
        }
    }
}
