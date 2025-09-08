using MediatR;

namespace FitFalTracker.Application.Workout.Command.UpdateWorkout;

public sealed record UpdateWorkoutCommand() : IRequest<Unit>
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public DateTime? Date { get; init; }
}