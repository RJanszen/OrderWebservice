using AutoMapper;
using Optimizers.Order.Domain.Order;
using Optimizers.Order.Infrastructure.Contracts;
using Optimizers.Order.Services.Contracts.DTO.Order;
using Optimizers.Order.Services.Contracts.Interfaces;

namespace Optimizers.Order.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _autoMapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Domain.Order.Order> _repository;
        private readonly IRepository<Domain.User.User> _userRepository;

        public OrderService(IMapper autoMapper, IUnitOfWork unitOfWork, IRepository<Domain.Order.Order> repository, IRepository<Domain.User.User> userRepository)
        {
            _autoMapper = autoMapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<List<OrderDTO>?> Get(long userId)
        {
            var user = await GetUserIdAsync(userId);
            if (user == null)
                return null;

            var orders = _repository.Get().Where(o => o.User == user);
            if (!orders.Any())
                return null;

            return _autoMapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO?> GetById(long userId, long id)
        {
            var user = await GetUserIdAsync(userId);
            if (user == null)
                return null;

            var order = await GetOrderByIdAsync(id, user);
            if (order == null)
                return null;

            return _autoMapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO?> Create(long userId, CreateOrderDTO dto)
        {
            var user = await GetUserIdAsync(userId);
            if (user == null)
                return null;

            var order = _autoMapper.Map<Domain.Order.Order>(dto);
            order.User = user;

            _repository.Insert(order);
            _unitOfWork.Save();

            return _autoMapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO?> Delete(long userId, long id)
        {
            var user = await GetUserIdAsync(userId);
            if (user == null)
                return null;

            var order = await GetOrderByIdAsync(id, user);
            if (order == null)
                return null;

            var dto = _autoMapper.Map<OrderDTO>(order);

            _repository.Delete(order);
            _unitOfWork.Save();

            return dto;
        }

        public async Task<OrderDTO?> Update(long userId, long id, UpdateOrderDTO dto)
        {
            var user = await GetUserIdAsync(userId);
            if (user == null)
                return null;

            var order = await GetOrderByIdAsync(id, user);
            if (order == null)
                return null;

            _autoMapper.Map(dto, order);
            _unitOfWork.Save();

            return _autoMapper.Map<OrderDTO>(order);
        }


        public async Task<OrderLineDTO?> CreateOrderLine(long userId, long id, CreateOrderLineDTO dto)
        {
            var user = await GetUserIdAsync(userId);
            if (user == null)
                return null;

            var order = await GetOrderByIdAsync(id, user);
            if (order == null)
                return null;

            var orderLine = _autoMapper.Map<OrderLine>(dto);
            order.OrderLines.Add(orderLine);

            _unitOfWork.Save();

            return _autoMapper.Map<OrderLineDTO>(orderLine);
        }

        public async Task<OrderLineDTO?> UpdateOrderLine(long userId, long orderLineId, UpdateOrderLineDTO dto)
        {
            var user = await GetUserIdAsync(userId);
            if (user == null)
                return null;

            var orderLine = await GetOrderLineByIdAsync(orderLineId, user);
            if (orderLine == null)
                return null;

            _autoMapper.Map(dto, orderLine);
            _unitOfWork.Save();

            return _autoMapper.Map<OrderLineDTO>(orderLine);
        }

        public async Task<OrderLineDTO?> DeleteOrderLine(long userId, long orderLineId)
        {
            var user = await GetUserIdAsync(userId);
            if (user == null)
                return null;

            var orderLine = await GetOrderLineByIdAsync(orderLineId, user);
            if (orderLine == null)
                return null;

            var dto = _autoMapper.Map<OrderLineDTO>(orderLine);

            orderLine.Order.OrderLines.Remove(orderLine);
            _unitOfWork.Save();

            return dto;
        }

        private async Task<Domain.User.User?> GetUserIdAsync(long id) => _userRepository.Get().FirstOrDefault(o => o.Id == id);
        private async Task<Domain.Order.Order?> GetOrderByIdAsync(long id, Domain.User.User user) => _repository.Get().FirstOrDefault(o => o.Id == id && o.User == user);
        private async Task<OrderLine?> GetOrderLineByIdAsync(long id, Domain.User.User user) => _repository.Get().SelectMany(o => o.OrderLines).FirstOrDefault(o => o.Id == id && o.Order.User == user);
    }
}
