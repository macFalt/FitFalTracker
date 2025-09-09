using FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;
using FitFalTracker.Domain.Entities;

namespace FitFalTracker.Application.Exercises.Queries.GetAllExerciseDetails;

public record AllExerciseDetailForExerciseVm
{
    public ICollection<ExerciseDetailVm> ExerciseDetails { get; init; }
    

}