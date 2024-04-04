using Domain.Models;

namespace Domain.Abstraction
{
    public interface IProductService
    {
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<Product?> GetByNameAsync(string name);
        Task<IEnumerable<Product>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
