using MediatR;

namespace FitFalTracker.Application.Workout.Queries.GetWorkout;

public class GetWorkoutQuery : IRequest<WorkoutVm>
{
    public int WorkoutId { get; set; }
}