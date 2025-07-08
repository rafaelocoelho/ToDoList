using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.Utilities
{
    public class ValidDateOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return ValidationResult.Success;
            }

            if (value is DateOnly)
            {                
                return ValidationResult.Success;
            }
            
            return new ValidationResult("O valor deve ser uma data válida.");
        }
    }
}
