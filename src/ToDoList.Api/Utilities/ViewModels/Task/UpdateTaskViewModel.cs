using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.Utilities
{
    public record UpdateTaskViewModel(
        [MaxLength(ErrorMessage = "O título não pode ultrapassar 200 caracteres")] string? Title,
        [MaxLength(ErrorMessage = "A descrição não pode ultrapassar 500 caracteres")] string? Description,
        [FutureOrPresentDate(ErrorMessage = "A data de vencimento precisa ser igual ou posterior à data atual.")] DateOnly? DueDate,
        [TaskStatusDataType(ErrorMessage = "O status da tarefa não pode ser vazio")] Domain.Enums.TaskStatus? Status
    );
}
