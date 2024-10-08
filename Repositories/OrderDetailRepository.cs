using BusinessObject;
using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDetailDAO _orderDetailDAO;

        public OrderDetailRepository(OrderDetailDAO orderDetailDAO)
        {
            _orderDetailDAO = orderDetailDAO;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _orderDetailDAO.GetAllOrderDetailsAsync();
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int orderId, int productId)
        {
            return await _orderDetailDAO.GetOrderDetailByIdAsync(orderId, productId);
        }

        public async Task AddOrderDetailAsync(OrderDetailDto orderDetailDto)
        {
            await _orderDetailDAO.CreateOrderDetailAsync(orderDetailDto);
        }

        public async Task UpdateOrderDetailAsync(int orderId, int productId, OrderDetailDto orderDetailDto)
        {
            await _orderDetailDAO.UpdateOrderDetailAsync(orderId, productId, orderDetailDto);
        }

        public async Task DeleteOrderDetailAsync(int orderId, int productId)
        {
            await _orderDetailDAO.DeleteOrderDetailAsync(orderId, productId);
        }
    }
}
