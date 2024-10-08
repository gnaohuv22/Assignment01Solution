using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPI : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderAPI(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //GET: api/Order/GetAllOrders
        [HttpGet("GetAllOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Ok(orders);
        }

        //GET: api/Order/GetOrderById/{id}
        [HttpGet("GetOrderById/{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return Ok(order);
        }

        //POST: api/Order/AddOrder
        [HttpPost("AddOrder")]
        public async Task<ActionResult<Order>> AddOrder(OrderDto orderDto)
        {
            await _orderRepository.AddOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderDto.OrderId }, orderDto);
        }

        //PUT: api/Order/UpdateOrder/{id}
        [HttpPut("UpdateOrder/{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, OrderDto orderDto)
        {
            await _orderRepository.UpdateOrderAsync(id, orderDto);
            return NoContent();
        }

        //DELETE: api/Order/DeleteOrder/{id}
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
