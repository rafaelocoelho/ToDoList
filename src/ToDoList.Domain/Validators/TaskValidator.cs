using FluentValidation;

namespace ToDoList.Domain.Validators
{
    public class TaskValidator : AbstractValidator<Domain.Entities.Task>
    {
        public TaskValidator() 
        { 
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status must be a valid value.");
        }
    }
}
