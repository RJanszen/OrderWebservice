namespace Optimizers.Order.Domain.Order
{
    public class OrderLine
    {
        public long Id { get; set; }

        public Order Order { get; set; }

        public int? LineNumber { get; set; }

        public string ItemCode { get; set; } = string.Empty;

        public decimal Quantity { get; set; } = decimal.Zero;

        public decimal Price { get; set; } = decimal.Zero;
    }
}
