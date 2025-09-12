using MediatR;

namespace FitFalTracker.Application.Exercise.Queries.GetAllExercise;

public record GetAllExerciseForWorkoutQuery : IRequest<AllExerciseForWorkoutVm>
{
    public int WorkoutId { get; init; }
}