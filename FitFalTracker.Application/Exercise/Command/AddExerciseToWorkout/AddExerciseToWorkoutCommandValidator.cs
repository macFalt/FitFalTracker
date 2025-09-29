using FluentValidation;

namespace FitFalTracker.Application.Exercise.Command.AddExerciseToWorkout;

public class AddExerciseToWorkoutCommandValidator : AbstractValidator<AddExerciseToWorkoutCommand>
{
    public AddExerciseToWorkoutCommandValidator()
    {
        RuleFor(x=>x.ExerciseDefinitionId)
            .NotEmpty()
            .WithMessage("Exercise definition id is required.");
        RuleFor(x=>x.WorkoutId)
            .NotEmpty()
            .WithMessage("Workout id is required.");
        RuleFor(x => x.Order).GreaterThan(0)
            .WithMessage("Order must be greater than 0.");
    }
}