using AutoMapper;
using Optimizers.Order.Domain.Order;
using Optimizers.Order.Services.Contracts.DTO.Order;
using Optimizers.Order.Services.Contracts.DTO.User;

namespace Optimizers.Order.Configuration.Automapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Domain.User.User, UserDTO>();

            CreateMap<CreateUserDTO, Domain.User.User>();
            CreateMap<UpdateUserDTO, Domain.User.User>();

            CreateMap<Domain.Order.Order, OrderDTO>();

            CreateMap<CreateOrderDTO, Domain.Order.Order>();
            CreateMap<UpdateOrderDTO, Domain.Order.Order>();

            CreateMap<OrderLine, OrderLineDTO>();

            CreateMap<CreateOrderLineDTO, OrderLine>();
            CreateMap<UpdateOrderLineDTO, OrderLine>();
        }
    }
}
