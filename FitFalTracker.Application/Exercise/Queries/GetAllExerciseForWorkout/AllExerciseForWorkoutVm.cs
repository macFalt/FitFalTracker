using FitFalTracker.Application.Exercise.Queries.GetExercise;

namespace FitFalTracker.Application.Exercise.Queries.GetAllExercise;

public class AllExerciseForWorkoutVm
{
    public ICollection<ExerciseVm> Exercises { get; set; }
}