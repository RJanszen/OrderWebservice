using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Optimizers.Order.Infrastructure.Models
{
    public class OrderModel : IEntityTypeConfiguration<Domain.Order.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Order.Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(order => order.Id);
            builder.Property(order => order.OrderNumber);
            builder.Property(order => order.OrderDate).IsRequired();
            builder.Property(order => order.Reference).HasMaxLength(250);
            builder.Property(order => order.CustomerName).HasMaxLength(500).IsRequired();
            builder.HasOne(order => order.User).WithMany().IsRequired();
        }
    }
}