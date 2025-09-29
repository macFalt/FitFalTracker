using FluentValidation;

namespace FitFalTracker.Application.ExerciseDetails.Command.UpdateExerciseDetail;

public class UpdateExerciseDetailsCommandValidator : AbstractValidator<UpdateExerciseDetailsCommand>
{
    public UpdateExerciseDetailsCommandValidator()
    {
        When(x => x.Rpe != null, () =>
        {
            RuleFor(x => x.Rpe)
                .InclusiveBetween(1, 10).WithMessage("Rpe must be between 1 and 10.");
        });

        When(x => x.Rir != null, () =>
        {
            RuleFor(s => s.Rir)
                .InclusiveBetween(0, 5).WithMessage("Rir must be between 0 and 5.");
        });


        RuleFor(x => x.SetNumber)
            .GreaterThan(0).WithMessage("SetNumber must be greater than 0.");


        RuleFor(x => x.Weight)
            .NotNull().WithMessage("Weight is required.");

        When(x => x.Weight is not null, () =>
        {
            RuleFor(x => x.Weight!.Value)
                .GreaterThan(0)
                .WithMessage("Weight.Value must be greater than 0.");


            RuleFor(x => x.Weight!.WeightEnum)
                .IsInEnum()
                .WithMessage("Weight.Value must be greater than 0.");

        });
    }

}