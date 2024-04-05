using Domain.Models;
using Domain.ResponseModels;

namespace Application.Abstractions.Services
{
    public interface IProductService : IGenericRepository<Product>
    {
        Task<Product> UpdateAsync(Product product);
        Task<Product> GetByNameAsync(string name);
        Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync();
    }
}
