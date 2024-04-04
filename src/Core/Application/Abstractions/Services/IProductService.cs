using Domain.Models;

namespace Application.Abstractions.Services
{
    public interface IProductService : IGenericRepository<Product>
    {
        Task<Product> UpdateAsync(Product product);
        Task<Product> GetByNameAsync(string name);
    }
}
