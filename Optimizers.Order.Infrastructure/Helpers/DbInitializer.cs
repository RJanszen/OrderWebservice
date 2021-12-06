using Optimizers.Order.Persistence.DbContext;

namespace Optimizers.Order.Infrastructure.Helpers
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Orders.Any())
            {
                return;
            }

            var orders = new Domain.Order.Order[]
            {
            //new Domain.Order.Order{Id=Guid.NewGuid(),Name=Guid.NewGuid().ToString()},
            //new Domain.Order.Order{Id=Guid.NewGuid(),Name=Guid.NewGuid().ToString()},
            //new Domain.Order.Order{Id=Guid.NewGuid(),Name=Guid.NewGuid().ToString()},
            //new Domain.Order.Order{Id=Guid.NewGuid(),Name=Guid.NewGuid().ToString()},
            };

            foreach (var o in orders)
            {
                //o.Lines.Add(new OrderLine { Name = Guid.NewGuid().ToString() });
                //o.Lines.Add(new OrderLine { Name = Guid.NewGuid().ToString() });
                //o.Lines.Add(new OrderLine { Name = Guid.NewGuid().ToString() });

                context.Orders.Add(o);
            }

            context.SaveChanges();
        }
    }
}