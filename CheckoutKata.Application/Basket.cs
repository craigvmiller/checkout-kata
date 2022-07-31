namespace CheckoutKata.Application
{
    public class Basket
    {
        private readonly PromotionService _promotionService;
        private ICollection<BasketItemSummary> _items;
        private int _total;

        public int Total => _total;
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
            var total = 0;
            foreach (var item in _items)
            {
                foreach (var promotion in _promotionService.GetRelevantPromotions(item))
                {
                    if (promotion.PromotionType == PromotionType.PriceOverride)
                    {
                        total += promotion.Amount * (item.Quantity / promotion.QuantityRequired);
                        total += item.Item.UnitPrice * (item.Quantity % promotion.QuantityRequired);
                    }
                }
            }
            _total = total;
        }
    }

    public class BasketItem
    {
        public string SKU { get; set; }
        public int UnitPrice { get; set; }
    }

    public class BasketItemSummary
    {
        public BasketItem Item { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}