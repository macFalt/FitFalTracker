using MediatR;

namespace FitFalTracker.Application.Workout.Command.DeleteWorkout;

public record DeleteWorkoutCommand : IRequest<Unit>
{
    public int WorkoutId { get; init; }
}