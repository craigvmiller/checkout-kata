namespace CheckoutKata.Application.Promotion
{
    public class Promotion
    {
        public string ItemSKU { get; set; }
        public int QuantityRequired { get; set; }
        public PromotionType PromotionType { get; set; }
        public decimal Amount { get; set; }
    }
}
