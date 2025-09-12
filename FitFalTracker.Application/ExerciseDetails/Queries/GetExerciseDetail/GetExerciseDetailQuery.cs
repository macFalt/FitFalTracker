using MediatR;

namespace FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;

public record GetExerciseDetailQuery : IRequest<ExerciseDetailVm>
{
    public int ExerciseId { get; init; }
    public int ExerciseDetailId { get; init; }
}