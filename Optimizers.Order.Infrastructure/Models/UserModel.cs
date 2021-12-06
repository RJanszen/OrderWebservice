using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Optimizers.Order.Infrastructure.Models
{
    public class UserModel : IEntityTypeConfiguration<Domain.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User.User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.Id);
            builder.Property(user => user.UserName).IsRequired().HasMaxLength(100);
            builder.Property(user => user.Password).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(user => user.FullName).IsRequired().HasMaxLength(500);

            builder.HasIndex(user => user.UserName).IsUnique();
        }
    }
}
