using ToDoList.Core.Services.Interfaces;
using ToDoList.Infra.UnitOfWork;

namespace ToDoList.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<TaskDTO> Create(TaskDTO task)
        {
            var entity = new Domain.Entities.Task
            {
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
            };

            await _unitOfWork.Tasks.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return new TaskDTO (entity.Id, entity.Title, entity.Description, entity.CreatedAt, entity.DueDate, entity.Status);
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks()
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();
            return tasks.Select(task => new TaskDTO(task.Id, task.Title, task.Description, task.CreatedAt, task.DueDate, task.Status));
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasksByDueDate(DateOnly dueDate)
        {
            var tasks = await _unitOfWork.Tasks.GetAllTasksByDueDateAsync(dueDate);
            return tasks.Select(task => new TaskDTO(task.Id, task.Title, task.Description, task.CreatedAt, task.DueDate, task.Status));
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasksByStatusAsync(Domain.Enums.TaskStatus status)
        {
            var tasks = await _unitOfWork.Tasks.GetAllTasksByStatusAsync(status);
            return tasks.Select(task => new TaskDTO(task.Id, task.Title, task.Description, task.CreatedAt, task.DueDate, task.Status));
        }

        public async Task Remove(Guid Id)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(Id);
            if(task is not null)
            {
                _unitOfWork.Tasks.Delete(task);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<TaskDTO?> Update(TaskDTO task)
        {
            var entity = await _unitOfWork.Tasks.GetByIdAsync(task.Id);
            if (entity is not null)
            {
                entity.Title = task.Title ?? entity.Title;
                entity.Description = task.Description ?? entity.Description;
                entity.DueDate = task.DueDate ?? entity.DueDate;
                entity.Status = task.Status ?? entity.Status;

                _unitOfWork.Tasks.Update(entity);
                await _unitOfWork.CompleteAsync();
            }

            return entity is not null
                ? new TaskDTO(entity.Id, entity.Title, entity.Description, entity.CreatedAt, entity.DueDate, entity.Status)
                : null;
        }
    }
}
