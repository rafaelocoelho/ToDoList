using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.Utilities
{
    public record CreateTaskViewModel(
        [Required(ErrorMessage = "O título não pode ser vazio"), MaxLength(ErrorMessage = "O título não pode ultrapassar 200 caracteres")] string Title,
        [Required(ErrorMessage = "A descrição não pode ser vazia"), MaxLength(ErrorMessage = "A descrição não pode ultrapassar 500 caracteres")] string Description,
        [FutureOrPresentDate(ErrorMessage = "A data de vencimento precisa ser igual ou posterior à data atual.")] DateOnly? DueDate
    );
}
