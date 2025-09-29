using FluentValidation;

namespace FitFalTracker.Application.Exercise.Command.UpdateExercise;

public class UpdateExerciseCommandValidator : AbstractValidator<UpdateExerciseCommand>
{
    public UpdateExerciseCommandValidator()
    {
        RuleFor(x => x.Order)
            .GreaterThan(0)
            .When(x => x.Order.HasValue);
    }
}