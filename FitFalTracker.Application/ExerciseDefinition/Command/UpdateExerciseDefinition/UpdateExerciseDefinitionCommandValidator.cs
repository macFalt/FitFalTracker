using FluentValidation;

namespace FitFalTracker.Application.ExerciseDefinition.Command.UpdateExerciseDefinition;

public class UpdateExerciseDefinitionCommandValidator : AbstractValidator<UpdateExerciseDefinitionCommand>
{
    public UpdateExerciseDefinitionCommandValidator()
    {
        
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Equipment)
            .IsInEnum();

        RuleFor(x => x.MuscleGroup)
            .IsInEnum();

        When(x => x.Name != null, () =>
        {
            RuleFor(x => x.Name)
                .Must(s => !string.IsNullOrWhiteSpace(s))
                .WithMessage("Name cannot be empty or just whitespace.")
                .MaximumLength(50).WithMessage("Name can have max. 50 characters.");
        });
        
        When(x => x.Description != null, () =>
        {
            RuleFor(x => x.Description)
                .Must(s => !string.IsNullOrWhiteSpace(s))
                .WithMessage("Name cannot be empty or just whitespace.")
                .MaximumLength(250).WithMessage("Description can have max. 250 characters.");
        });


        RuleFor(x => x.ExerciseDefinitionId)
            .GreaterThan(0).WithMessage("ExerciseDefinitionId must be > 0.");
    }
}

