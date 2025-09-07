using FitFalTracker.Application.Workout.Queries.GetWorkout;

namespace FitFalTracker.Application.Workout.Queries.GetAllWorkout;

public record AllWorkoutVm
{
    public ICollection<WorkoutVm> Workouts { get; init; }
}