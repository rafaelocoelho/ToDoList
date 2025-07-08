using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoList.Infra.Contexts;

namespace ToDoList.Infra.Repositories
{
    public class TaskRepository : Repository<Domain.Entities.Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasksByDueDateAsync(DateOnly dueDate)
        {
            return await _dbSet.Where(task => 
                task.DueDate.HasValue && 
                task.DueDate.Value == dueDate).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasksByFilterParamsAsync(Expression<Func<Domain.Entities.Task, bool>> filter = null)
        {
            IQueryable<Domain.Entities.Task> query = filter is not null ? _dbSet.Where(filter) : _dbSet;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasksByStatusAsync(Domain.Enums.TaskStatus status)
        {
            return await _dbSet.Where(task =>
                task.Status.Equals(status)).ToListAsync();
        }
    }
}
