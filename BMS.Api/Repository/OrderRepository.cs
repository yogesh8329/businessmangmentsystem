using BMS.Api.Data;
using BMS.Core.Entities;
using BMS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BMS.Api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<Order?> UpdateAsync(int id, decimal totalAmount)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return null;

            order.TotalAmount = totalAmount;
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> UpdateStatusAsync(int id, string status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return null;

            order.Status = status;
            await _context.SaveChangesAsync();
            return order;
        }

    }
}
