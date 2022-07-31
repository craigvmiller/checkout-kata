namespace CheckoutKata.Web.Models
{
    public class BasketViewModel
    {
        public decimal Total { get; set; }
        public IEnumerable<BasketSummaryItemViewModel> Items { get; set; }
    }
}
