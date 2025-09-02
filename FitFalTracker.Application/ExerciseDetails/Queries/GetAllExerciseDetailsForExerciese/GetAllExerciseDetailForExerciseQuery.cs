using MediatR;

namespace FitFalTracker.Application.Exercises.Queries.GetAllExerciseDetails;

public class GetAllExerciseDetailForExerciseQuery : IRequest<AllExerciseDetailForExerciseVm>
{
    public int ExerciseId { get; set; }
}