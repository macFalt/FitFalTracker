using FitFalTracker.Application.Exercise.Queries.GetExercise;

namespace FitFalTracker.Application.Exercise.Queries.GetAllExercise;

public record AllExerciseForWorkoutVm
{
    public ICollection<ExerciseVm> Exercises { get; init; }
}