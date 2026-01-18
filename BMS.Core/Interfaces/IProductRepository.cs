using BMS.Core.Entities;

namespace BMS.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product?> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
