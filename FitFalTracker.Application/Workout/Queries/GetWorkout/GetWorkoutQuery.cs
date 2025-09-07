using MediatR;

namespace FitFalTracker.Application.Workout.Queries.GetWorkout;

public record GetWorkoutQuery : IRequest<WorkoutVm>
{
    public int WorkoutId { get; init; }
}