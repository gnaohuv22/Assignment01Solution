using BusinessObject;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task AddOrderAsync(OrderDto orderDto);
        Task UpdateOrderAsync(int id, OrderDto orderDto);
        Task DeleteOrderAsync(int id);
        Task<IEnumerable<Order>> GetOrderByMemberIdAsync(int memberId);
    }
}
