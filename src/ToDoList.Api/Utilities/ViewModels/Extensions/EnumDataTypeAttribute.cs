using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.Utilities
{
    public class TaskStatusDataTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return ValidationResult.Success;
            }

            if (Enum.IsDefined(typeof(Domain.Enums.TaskStatus), value))
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult(ErrorMessage ?? "O status informado é inválido.");
        }
    }
}
