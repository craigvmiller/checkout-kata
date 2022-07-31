namespace CheckoutKata.Application
{
    public class Promotion
    {
        public string ItemSKU { get; set; }
        public int QuantityRequired { get; set; }
        public PromotionType PromotionType { get; set; }
        public int Amount { get; set; }
    }

    public enum PromotionType
    {
        DiscountPercentage,
        PriceOverride
    }

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
