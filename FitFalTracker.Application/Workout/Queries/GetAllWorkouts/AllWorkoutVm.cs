using FitFalTracker.Application.Workout.Queries.GetWorkout;

namespace FitFalTracker.Application.Workout.Queries.GetAllWorkout;

public class AllWorkoutVm
{
    public ICollection<WorkoutVm> Workouts { get; set; }
}