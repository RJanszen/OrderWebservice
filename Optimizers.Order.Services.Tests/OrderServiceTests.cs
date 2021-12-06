using AutoMapper;
using Moq;
using NUnit.Framework;
using Optimizers.Order.Infrastructure.Contracts;
using Optimizers.Order.Services.Contracts.DTO.Order;
using Optimizers.Order.Services.Contracts.Interfaces;
using Optimizers.Order.Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optimizers.Order.Services.Tests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private IMapper _mapper;
        private IRepository<Domain.Order.Order> _repository;
        private IRepository<Domain.User.User> _userRepository;
        private IUnitOfWork _unitOfWork;

        private IOrderService _orderService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mapper = Mock.Of<IMapper>();
            _repository = Mock.Of<IRepository<Domain.Order.Order>>();
            _userRepository = Mock.Of<IRepository<Domain.User.User>>();
            _unitOfWork = Mock.Of<IUnitOfWork>();

            _orderService = new OrderService(_mapper, _unitOfWork, _repository, _userRepository);
        }

        [SetUp]
        public void Setup()
        {
            var users = PopulateUsersDb(2);
            Mock.Get(_repository).Setup(x => x.Get(It.IsAny<Expression<Func<Domain.Order.Order, bool>>>(), It.IsAny<Func<IQueryable<Domain.Order.Order>, IOrderedQueryable<Domain.Order.Order>>>(), It.IsAny<string>())).Returns(() => PopulateOrdersDb(users, 10));
            Mock.Get(_userRepository).Setup(x => x.Get(It.IsAny<Expression<Func<Domain.User.User, bool>>>(), It.IsAny<Func<IQueryable<Domain.User.User>, IOrderedQueryable<Domain.User.User>>>(), It.IsAny<string>())).Returns(() => users);

            Mock.Get(_mapper).Setup(x => x.Map<OrderDTO>(It.IsAny<Domain.Order.Order>())).Returns(() => new OrderDTO());
            Mock.Get(_mapper).Setup(x => x.Map<List<OrderDTO>>(It.IsAny<IEnumerable<Domain.Order.Order>>())).Returns(() => new List<OrderDTO>());
        }

        [Test]
        public async Task When_Get_NoOrders_NullReturned()
        {
            // Arrange
            Mock.Get(_repository).Setup(x => x.Get(It.IsAny<Expression<Func<Domain.Order.Order, bool>>>(), It.IsAny<Func<IQueryable<Domain.Order.Order>, IOrderedQueryable<Domain.Order.Order>>>(), It.IsAny<string>())).Returns(() => PopulateOrdersDb(null, 0));

            // Act
            var result = await _orderService.Get(1);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task When_Get_WithOrders_OrdersAreReturned()
        {
            // Act
            var result = await _orderService.Get(1);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task When_GetById_WithExistingOrder_OrderIsReturned()
        {
            // Act
            var result = await _orderService.GetById(1, 1);

            // Assert
            Assert.IsNotNull(result);
        }

        private static List<Domain.Order.Order> PopulateOrdersDb(List<Domain.User.User>? users, int population)
        {
            List<Domain.Order.Order> orders = new();
            if (users != null)
            {
                foreach (var user in users)
                {
                    for (int i = 1; i <= population; i++)
                    {
                        orders.Add(new Domain.Order.Order() { Id = i, User = user });
                    }
                }
            }

            return orders;
        }

        private static List<Domain.User.User> PopulateUsersDb(int population)
        {
            List<Domain.User.User> users = new();
            for (int i = 1; i <= population; i++)
            {
                users.Add(new Domain.User.User() { Id = i });
            }

            return users;
        }
    }
}