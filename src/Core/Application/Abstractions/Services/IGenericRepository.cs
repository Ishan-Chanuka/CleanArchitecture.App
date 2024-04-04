using Domain.Primitives;

namespace Application.Abstractions.Services
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<Result> CreateAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
