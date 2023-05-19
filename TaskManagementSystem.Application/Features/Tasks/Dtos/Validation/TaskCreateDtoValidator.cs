using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Features.Tasks.Dtos.Validation;
public class TaskCreateDtoValidator : AbstractValidator<TaskCreateDto>
{
    public TaskCreateDtoValidator()
    {
        RuleFor(t => t.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(t => t.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(t => t.DueDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThanOrEqualTo(System.DateTime.Now).WithMessage("{PropertyName} must not be in the past.");

        RuleFor(t => t.Priority)
            .InclusiveBetween(1, 5).WithMessage("{PropertyName} must be between {From} and {To}.");
    }
}