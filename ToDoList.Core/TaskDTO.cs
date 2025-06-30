namespace ToDoList.Core
{
    public record TaskDTO (Guid? Id, string Title, string Description, DateTime? CreatedAt, DateTime? DueDate, Domain.Enums.TaskStatus? Status);
}
