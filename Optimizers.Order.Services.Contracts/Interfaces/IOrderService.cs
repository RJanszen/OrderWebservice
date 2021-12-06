using Microsoft.AspNetCore.Mvc;
using Optimizers.Order.Services.Contracts.DTO.Order;

namespace Optimizers.Order.Services.Contracts.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>?> Get(long userId);
        Task<OrderDTO?> GetById(long userId, long id);
        Task<OrderDTO?> Create(long userId, CreateOrderDTO dto);
        Task<OrderDTO?> Update(long userId, long id, UpdateOrderDTO dto);
        Task<OrderDTO?> Delete(long userId, long id);

        Task<OrderLineDTO?> CreateOrderLine(long userId, long id, CreateOrderLineDTO dto);
        Task<OrderLineDTO?> UpdateOrderLine(long userId, long orderLineId, UpdateOrderLineDTO dto);
        Task<OrderLineDTO?> DeleteOrderLine(long userId, long orderLineId);
    }
}
