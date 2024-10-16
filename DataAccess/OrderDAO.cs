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
    public class OrderDAO
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderDAO(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            return _mapper.Map<IEnumerable<Order>>(orders);
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return _mapper.Map<Order>(order);
        }

        public async Task CreateOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(int id, OrderDto orderDto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            _mapper.Map(orderDto, order);
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrderByMemberIdAsync(int memberId)
        {
            var orders = await _context.Orders
                .Where(x => x.MemberId == memberId).ToListAsync();
            return orders;
        }
    }
}

