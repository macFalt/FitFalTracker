using FitFalTracker.Application.Workout.Command.CreateWorkout;
using FluentValidation;

namespace FitFalTracker.Application.Workout.Command.UpdateWorkout;

public class UpdateWorkoutCommandValidator : AbstractValidator<UpdateWorkoutCommand>
{
    public UpdateWorkoutCommandValidator()
    {
        RuleFor(x=>x.Date).NotEmpty();
        RuleFor(x=>x.Name)
            .Must(s => !string.IsNullOrWhiteSpace(s)).WithMessage("Name is required and cannot be whitespace.")
            .MaximumLength(50).WithMessage("Name must be at most 50 characters.");
    }
}