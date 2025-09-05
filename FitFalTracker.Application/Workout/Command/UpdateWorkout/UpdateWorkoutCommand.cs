using MediatR;

namespace FitFalTracker.Application.Workout.Command.UpdateWorkout;

public sealed record UpdateWorkoutCommand(int Id,DateTime Date,string Name) : IRequest<UpdateWorkoutDTO>
{
}