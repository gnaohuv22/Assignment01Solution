using BusinessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync();
        Task<OrderDetail> GetOrderDetailByIdAsync(int productId, int orderId);
        Task AddOrderDetailAsync(OrderDetailDto orderDetailDto);
        Task UpdateOrderDetailAsync(int productId, int orderId, OrderDetailDto orderDetailDto);
        Task DeleteOrderDetailAsync(int productId, int orderId);
    }
}
