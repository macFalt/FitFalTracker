using MediatR;

namespace FitFalTracker.Application.Exercise.Queries.GetAllExercise;

public class GetAllExerciseForWorkoutQuery : IRequest<AllExerciseForWorkoutVm>
{
    public int WorkoutId { get; set; }
}