using MediatR;

namespace FitFalTracker.Application.Exercises.Queries.GetAllExerciseDetails;

public record GetAllExerciseDetailForExerciseQuery : IRequest<AllExerciseDetailForExerciseVm>
{
    public int ExerciseId { get; init; }
}