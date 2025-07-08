using ToDoList.Core.DTOs;

namespace ToDoList.Core
{
    public interface ITaskService
    {
        Task<TaskDTO> Create(TaskDTO task);
        Task<TaskDTO> Update(TaskDTO task);
        Task Remove(Guid Id);

        Task<TaskDTO> GetTaskById(Guid Id);
        Task<IEnumerable<TaskDTO>?> GetAllTasks();
        Task<IEnumerable<TaskDTO>?> GetAllTasksByFilter(TaskFilterParamsDTO search);

    }
}
