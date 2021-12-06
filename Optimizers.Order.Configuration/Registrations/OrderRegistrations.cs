using Microsoft.Extensions.DependencyInjection;
using Optimizers.Order.Infrastructure.Contracts;
using Optimizers.Order.Infrastructure.DbContext;
using Optimizers.Order.Services.Contracts.Interfaces;
using Optimizers.Order.Services.Order;
using Optimizers.Order.Services.User;

namespace Optimizers.Order.Configuration.Registrations
{
    public static class OrderRegistrations
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Domain.Order.Order>, Repository<Domain.Order.Order>>();
            services.AddScoped<IRepository<Domain.User.User>, Repository<Domain.User.User>>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
