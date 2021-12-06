using Microsoft.EntityFrameworkCore;
using Optimizers.Order.Domain.User;

namespace Optimizers.Order.Infrastructure.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Order.Order> Orders { get; set; }
        DbSet<User> Users { get; set; }
        void SaveChanges();
    }
}
