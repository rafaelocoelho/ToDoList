namespace ToDoList.Core
{
    public record TaskDTO (Guid? Id, string? Title, string? Description, DateTime? CreatedAt, DateOnly? DueDate, Domain.Enums.TaskStatus? Status);
}
