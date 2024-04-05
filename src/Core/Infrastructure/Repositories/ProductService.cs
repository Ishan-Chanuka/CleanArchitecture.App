using Application.Abstractions.Services;
using Domain.Models;
using Domain.ResponseModels;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductService : GenericRepository<Product>, IProductService
    {
        public ProductService(AppDbContext context) : base(context) { }

        public async Task<Product> GetByNameAsync(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);

            return product;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync()
        {
            var products = await _context.Products
                .Select(p => new ProductResponseModel
                {
                    Id = p.Id,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                })
                .ToListAsync();

            return products;
        }

        public async Task<ProductResponseModel?> GetByIdAsync(Guid id)
        {
            var product = await _context.Products
                .Select(p => new ProductResponseModel
                {
                    Id = p.Id,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                })
                .FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
