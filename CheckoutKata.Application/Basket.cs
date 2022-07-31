namespace CheckoutKata.Application
{
    public class Basket
    {
        private ICollection<BasketItem> _items;
        private int _total;

        public ICollection<BasketItem> Items => _items;
        public int Total => _total;

        public Basket()
        {
            _items = new List<BasketItem>();
        }

        public void Add(BasketItem item)
        {
            _items.Add(item);
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            _total = _items.Sum(x => x.UnitPrice);
        }
    }

    public class BasketItem
    {
        public string SKU { get; set; }
        public int UnitPrice { get; set; }
    }
}