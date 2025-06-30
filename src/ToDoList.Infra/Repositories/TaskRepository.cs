using Microsoft.EntityFrameworkCore;
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
                task.DueDate.Value.Date.Equals(dueDate)).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasksByStatusAsync(Domain.Enums.TaskStatus status)
        {
            return await _dbSet.Where(task =>
                task.Status.Equals(status)).ToListAsync();
        }
    }
}
