using Optimizers.Order.Services.Contracts.DTO.User;

namespace Optimizers.Order.Services.Contracts.DTO.Order
{
    public record OrderDTO
    {
        public long Id { get; set; }
        public int? OrderNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string? Reference { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public UserDTO User { get; set; }

        public ICollection<OrderLineDTO> OrderLines { get; set; } = new List<OrderLineDTO>();
    }
}
