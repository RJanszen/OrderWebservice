namespace Optimizers.Order.Services.Contracts.DTO.Order
{
    public record CreateOrderDTO
    {
        public int? OrderNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string? Reference { get; set; }

        public string CustomerName { get; set; } = string.Empty;
    }
}
