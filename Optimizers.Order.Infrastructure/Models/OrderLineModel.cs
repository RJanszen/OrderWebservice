using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optimizers.Order.Domain.Order;

namespace Optimizers.Order.Infrastructure.Models
{
    public class OrderLineModel : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable("OrderLine");
            builder.HasKey(orderLine => orderLine.Id);
            builder.HasOne(orderLine => orderLine.Order).WithMany(order => order.OrderLines);
            builder.Property(orderLine => orderLine.LineNumber);
            builder.Property(orderLine => orderLine.ItemCode).HasMaxLength(250).IsRequired();
            builder.Property(orderLine => orderLine.Quantity).HasPrecision(18, 3).IsRequired();
            builder.Property(orderLine => orderLine.Price).HasPrecision(18, 9).IsRequired();
        }
    }
}
