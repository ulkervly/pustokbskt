using Microsoft.EntityFrameworkCore;
using PustokPractice.Models;
using PustokPractice.Models;
using System.Linq.Expressions;

namespace Pustok.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> 
                        where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table { get; }

        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes);

        Task<int> CommitAsync();
    }
}
