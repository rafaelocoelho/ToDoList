using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ToDoList.Infra.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetQueryable();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllByFilterParams(Expression<Func<TEntity, bool>> filterParams);
        Task<IEnumerable<TEntity>> GetAllAsync();
        System.Threading.Tasks.Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
