using Optimizers.Order.Infrastructure.Contracts;
using Optimizers.Order.Persistence.DbContext;

namespace Optimizers.Order.Infrastructure.DbContext
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IRepository<Domain.User.User> _userRepository;
        private IRepository<Domain.Order.Order> _orderRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Domain.User.User> UserRepository
        {
            get
            {

                if (_userRepository == null)
                {
                    _userRepository = new Repository<Domain.User.User>(_context);
                }
                return _userRepository;
            }
        }

        public IRepository<Domain.Order.Order> OrderRepository
        {
            get
            {

                if (_orderRepository == null)
                {
                    _orderRepository = new Repository<Domain.Order.Order>(_context);
                }
                return _orderRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
