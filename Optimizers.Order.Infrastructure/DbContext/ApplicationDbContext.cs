using Microsoft.EntityFrameworkCore;
using Optimizers.Order.Infrastructure.Contracts;
using Optimizers.Order.Infrastructure.Models;

namespace Optimizers.Order.Persistence.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Order.Order> Orders { get; set; }
        public DbSet<Domain.User.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderModel).Assembly);
        }

        void IApplicationDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
