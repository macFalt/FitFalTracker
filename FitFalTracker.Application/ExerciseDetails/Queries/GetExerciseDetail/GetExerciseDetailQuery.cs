using MediatR;

namespace FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;

public class GetExerciseDetailQuery : IRequest<ExerciseDetailVm>
{
    public int ExerciseId { get; set; }
}