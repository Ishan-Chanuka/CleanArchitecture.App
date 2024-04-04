using Application.Abstractions.Services;
using Domain.Primitives;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result> CreateAsync(TEntity entity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Result.Success();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
