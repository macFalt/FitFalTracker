using MediatR;

namespace FitFalTracker.Application.Exercise.Queries.GetExercise;

public record GetExerciseQuery : IRequest<ExerciseVm>
{
    public int  ExerciseId { get; init; }
    public int WorkoutId { get; init; }
}