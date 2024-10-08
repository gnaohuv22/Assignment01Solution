using AutoMapper;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderDetailDAO(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync()
        {
            var orderDetails = await _context.OrderDetails.ToListAsync();
            return _mapper.Map<IEnumerable<OrderDetail>>(orderDetails);
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int orderId, int productId)
        {
            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
            return _mapper.Map<OrderDetail>(orderDetail);
        }

        public async Task CreateOrderDetailAsync(OrderDetailDto orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailAsync(int orderId, int productId, OrderDetailDto orderDetailDto)
        {
            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
            if (orderDetail == null)
            {
                throw new KeyNotFoundException("Product detail not found");
            }
            _mapper.Map(orderDetailDto, orderDetail);
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderDetailAsync(int orderId, int productId)
        {
            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
            if (orderDetail == null)
            {
                throw new KeyNotFoundException("Product detail not found");
            }
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
        }
    }
}
