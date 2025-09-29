using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitFalTracker.Application.ExerciseDefinition.Command.AddNewExerciseDefinition;

public class AddNewExerciseDefinitionCommandValidator : AbstractValidator<AddNewExerciseDefinitionCommand>
{
    public AddNewExerciseDefinitionCommandValidator()
    {
        RuleFor(x => x.Name)
            .Must(s => !string.IsNullOrWhiteSpace(s)).WithMessage("Name is required and cannot be whitespace.")
            .MaximumLength(50).WithMessage("Name must be at most 50 characters.");
        
        
        RuleFor(x=>x.Equipment)
            .IsInEnum().WithMessage("Equipment must be a valid Equipment");
        
        RuleFor(x => x.MuscleGroup)
            .IsInEnum().WithMessage("MuscleGroup must be a valid MuscleGroup");

        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description can have max. 250 characters.");
    }
}