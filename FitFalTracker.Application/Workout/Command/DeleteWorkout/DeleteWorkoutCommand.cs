using MediatR;

namespace FitFalTracker.Application.Workout.Command.DeleteWorkout;

public class DeleteWorkoutCommand : IRequest<bool>
{
    public int WorkoutId { get; set; }
}