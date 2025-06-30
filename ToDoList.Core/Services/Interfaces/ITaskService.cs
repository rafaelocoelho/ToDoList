namespace ToDoList.Core.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDTO> Create(TaskDTO task);
        Task<TaskDTO> Update(TaskDTO task);
        Task Remove(Guid Id);

        Task<IEnumerable<TaskDTO>> GetAllTasks();
        Task<IEnumerable<TaskDTO>> GetAllTasksByDueDate(DateOnly dueDate);
        Task<IEnumerable<TaskDTO>> GetAllTasksByStatusAsync(Domain.Enums.TaskStatus status);
    }
}
