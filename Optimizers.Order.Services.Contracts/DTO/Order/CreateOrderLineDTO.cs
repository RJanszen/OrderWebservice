namespace Optimizers.Order.Services.Contracts.DTO.Order
{
    public record CreateOrderLineDTO
    {
        public int? LineNumber { get; set; }

        public string ItemCode { get; set; } = string.Empty;

        public decimal Quantity { get; set; } = decimal.Zero;

        public decimal Price { get; set; } = decimal.Zero;
    }
}
