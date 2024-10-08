using BusinessObject;
using DataAccess;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _orderDAO;

        public OrderRepository(OrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        public async Task AddOrderAsync(OrderDto orderDto)
        {
            await _orderDAO.CreateOrderAsync(orderDto);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderDAO.DeleteOrderAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderDAO.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderDAO.GetOrderByIdAsync(id);
        }

        public async Task UpdateOrderAsync(int id, OrderDto orderDto)
        {
            await _orderDAO.UpdateOrderAsync(id, orderDto);
        }
    }
}
