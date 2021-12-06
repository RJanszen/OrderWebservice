namespace Optimizers.Order.Domain.Order
{
    public class Order
    {
        public long Id { get; set; }
        public int? OrderNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string? Reference { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public User.User User { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
