using Application.Abstractions.Services;
using Domain.Exceptions;
using Domain.Models;
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

            return product ?? throw new NotFoundException(nameof(Product), name);
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
