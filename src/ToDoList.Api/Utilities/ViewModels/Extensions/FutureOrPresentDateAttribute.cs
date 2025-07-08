using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.Utilities
{
    public class FutureOrPresentDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return ValidationResult.Success;
            }

            if (value is DateOnly date)
            {
                if (date < DateOnly.FromDateTime(DateTime.Today))
                {
                    return new ValidationResult("A data deve ser no futuro ou presente.");
                }

                return ValidationResult.Success;
            }
            
            return new ValidationResult(ErrorMessage ?? "O valor deve ser uma data válida.");
        }
    }
}
