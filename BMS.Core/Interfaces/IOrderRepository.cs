using BMS.Core.Entities;

namespace BMS.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<List<Order>> GetAllAsync();
    }
}
