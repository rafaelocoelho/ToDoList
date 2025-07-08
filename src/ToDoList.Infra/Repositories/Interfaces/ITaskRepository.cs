
using System.Linq.Expressions;

namespace ToDoList.Infra.Repositories
{
    public interface ITaskRepository : IRepository<Domain.Entities.Task>
    {
        Task<IEnumerable<Domain.Entities.Task>> GetAllTasksByDueDateAsync(DateOnly dueDate);
        Task<IEnumerable<Domain.Entities.Task>> GetAllTasksByStatusAsync(Domain.Enums.TaskStatus status);
    }
}
