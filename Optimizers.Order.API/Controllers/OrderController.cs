using Microsoft.AspNetCore.Mvc;
using Optimizers.Order.Services.Contracts.DTO.Order;
using Optimizers.Order.Services.Contracts.Interfaces;

namespace Optimizers.Order.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Gets all orders
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get(long userId)
        {
            var orders = await _orderService.Get(userId);
            if (orders == null)
                return NotFound();

            return Ok(orders);
        }

        /// <summary>
        /// Gets an order by id
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the order</param>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long userId, long id)
        {
            var order = await _orderService.GetById(userId, id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="dto">A dto containing the new order</param>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(long userId, CreateOrderDTO dto)
        {
            var order = await _orderService.Create(userId, dto);

            return CreatedAtAction(nameof(Create), order);
        }

        /// <summary>
        /// Updates an existing order
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the order to update</param>
        /// <param name="outboundDelivery">A dto containing the update</param>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(long userId, long id, UpdateOrderDTO dto)
        {
            var order = await _orderService.Update(userId, id, dto);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        /// <summary>
        /// Deletes an existing order
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the order to delete</param>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long userId, long id)
        {
            var order = await _orderService.Delete(userId, id);
            if (order is null)
                return NotFound();
            else
                return Ok(order);
        }


        /// <summary>
        /// Creates a new order line
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="orderId">The id of the order to which the line should be added</param>
        /// <param name="dto">A dto containing the new order line</param>
        [HttpPost]
        [Route("orderline")]
        public async Task<IActionResult> CreateOrderLine(long userId, long orderId, CreateOrderLineDTO dto)
        {
            var orderLine = await _orderService.CreateOrderLine(userId, orderId, dto);

            return CreatedAtAction(nameof(CreateOrderLine), orderLine);
        }

        /// <summary>
        /// Updates an existing order line
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="orderLineId">The id of the order line to update</param>
        /// <param name="outboundDelivery">A dto containing the update</param>
        [HttpPut]
        [Route("orderline/{id}")]
        public async Task<IActionResult> UpdateOrderLine(long userId, long orderLineId, UpdateOrderLineDTO dto)
        {
            var orderLine = await _orderService.UpdateOrderLine(userId, orderLineId, dto);
            if (orderLine is null)
                return NotFound();
            else
                return Ok(orderLine);
        }

        /// <summary>
        /// Deletes an existing order line
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the order line to delete</param>
        [HttpDelete]
        [Route("orderline/{id}")]
        public async Task<IActionResult> DeleteOrderLine(long userId, long orderLineId)
        {
            var orderLine = await _orderService.DeleteOrderLine(userId, orderLineId);
            if (orderLine is null)
                return NotFound();
            else
                return Ok(orderLine);
        }
    }
}
