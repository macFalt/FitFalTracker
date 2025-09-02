using MediatR;

namespace FitFalTracker.Application.Exercise.Queries.GetExercise;

public class GetExerciseQuery : IRequest<ExerciseVm>
{
    public int  ExerciseId { get; set; }
}