namespace ToDoList.Api.Utilities
{
    public record FilterTaskViewModel(
        [ValidDateOnly] DateOnly? dueDate,
        [TaskStatusDataType] Domain.Enums.TaskStatus? taskStatus);
}
