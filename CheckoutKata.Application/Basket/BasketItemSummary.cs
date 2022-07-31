namespace CheckoutKata.Application.Basket
{
    public class BasketItemSummary
    {
        public BasketItem Item { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}