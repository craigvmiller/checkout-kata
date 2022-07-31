namespace CheckoutKata.Web.Models
{
    public class BasketSummaryItemViewModel
    {
        public string ItemSKU { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
