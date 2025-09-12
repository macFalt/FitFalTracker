using MediatR;

namespace FitFalTracker.Application.Exercise.Command.DeleteExerciseFromWorkout;

public record DeleteExerciseFromWorkoutCommand : IRequest<Unit>
{
    public int  ExerciseId { get; init; }
    public int WorkoutId { get; init; }
}