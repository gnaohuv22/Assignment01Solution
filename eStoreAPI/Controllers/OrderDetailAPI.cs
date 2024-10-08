using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailAPI : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailAPI(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        //GET: api/OrderDetail/GetAllOrderDetails
        [HttpGet("GetAllOrderDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetAllOrderDetails()
        {
            var orderDetails = await _orderDetailRepository.GetAllOrderDetailsAsync();
            return Ok(orderDetails);
        }

        //GET: api/OrderDetail/GetOrderDetailById/{id}
        [HttpGet("GetOrderDetailById/{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetailById(int productId, int orderId)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetailByIdAsync(orderId, productId);
            return Ok(orderDetail);
        }

        //POST: api/OrderDetail/AddOrderDetail
        [HttpPost("AddOrderDetail")]
        public async Task<ActionResult<OrderDetail>> AddOrderDetail(OrderDetailDto orderDetailDto)
        {
            await _orderDetailRepository.AddOrderDetailAsync(orderDetailDto);
            return CreatedAtAction(nameof(GetOrderDetailById), new { id = orderDetailDto.OrderId }, orderDetailDto);
        }

        //PUT: api/OrderDetail/UpdateOrderDetail/{id}
        [HttpPut("UpdateOrderDetail/{id}")]
        public async Task<ActionResult<OrderDetail>> UpdateOrderDetail(int productId, int orderId, OrderDetailDto orderDetailDto)
        {
            await _orderDetailRepository.UpdateOrderDetailAsync(productId, orderId, orderDetailDto);
            return NoContent();
        }

        //DELETE: api/OrderDetail/DeleteOrderDetail/{id}
        [HttpDelete("DeleteOrderDetail/{id}")]
        public async Task<ActionResult<OrderDetail>> DeleteOrderDetail(int productId, int orderId)
        {
            await _orderDetailRepository.DeleteOrderDetailAsync(productId, orderId);
            return NoContent();
        }
    }
}
