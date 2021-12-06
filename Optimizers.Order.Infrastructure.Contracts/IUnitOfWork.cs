using Optimizers.Order.Domain.User;

namespace Optimizers.Order.Infrastructure.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Domain.Order.Order> OrderRepository { get; }
        IRepository<User> UserRepository { get; }

        void Dispose();
        void Save();
    }
}