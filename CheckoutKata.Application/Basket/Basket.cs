using CheckoutKata.Application.Promotion;

namespace CheckoutKata.Application.Basket
{
    public class Basket
    {
        private readonly PromotionService _promotionService;
        private ICollection<BasketItemSummary> _items;
        private decimal _total;

        public decimal Total => _total;
        public int Count => _items.Sum(i => i.Quantity);

        public Basket()
        {
            _items = new List<BasketItemSummary>();
            _promotionService = new PromotionService();
        }

        public void Add(BasketItem item)
        {
            var existing = _items.SingleOrDefault(i => i.Item.SKU == item.SKU);
            if (existing != null)
            {
                existing.Quantity++;
                existing.Total = item.UnitPrice * existing.Quantity;
            }
            else
            {
                _items.Add(new BasketItemSummary
                {
                    Item = item,
                    Quantity = 1,
                    Total = item.UnitPrice,
                });
            }
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            var total = 0m;
            foreach (var item in _items)
            {
                var promotions = _promotionService.GetRelevantPromotions(item);
                if (promotions.Any())
                {
                    foreach (var promotion in _promotionService.GetRelevantPromotions(item))
                    {
                        if (promotion.PromotionType == PromotionType.PriceOverride)
                        {
                            total += promotion.Amount * (item.Quantity / promotion.QuantityRequired);
                            total += item.Item.UnitPrice * (item.Quantity % promotion.QuantityRequired);
                        }

                        if (promotion.PromotionType == PromotionType.DiscountPercentage)
                        {
                            var discountAmount = promotion.Amount / 100 * item.Item.UnitPrice;
                            discountAmount *= item.Quantity / promotion.QuantityRequired;
                            total += item.Item.UnitPrice * item.Quantity - discountAmount;
                        }
                    }
                }
                else
                {
                    total += item.Item.UnitPrice * item.Quantity;
                }
            }
            _total = total;
        }
    }
}