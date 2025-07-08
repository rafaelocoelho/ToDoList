namespace ToDoList.Core.DTOs
{
    public record TaskFilterParamsDTO (DateOnly? DueDate, Domain.Enums.TaskStatus? Status);
}
