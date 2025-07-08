using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoList.Infra.Contexts;

namespace ToDoList.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>() ?? throw new InvalidOperationException($"Could not set DbSet for type {typeof(T).Name}");
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"Entity with id {id} not found.");
        }

        public async Task<IEnumerable<T>> GetAllByFilterParams(Expression<Func<T, bool>> filterParams)
        {
            return await _dbSet.Where(filterParams).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }        

        public async System.Threading.Tasks.Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }        

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
