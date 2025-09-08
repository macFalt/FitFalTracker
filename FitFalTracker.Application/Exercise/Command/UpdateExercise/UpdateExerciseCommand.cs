using MediatR;

namespace FitFalTracker.Application.Exercise.Command.UpdateExercise;

public record UpdateExerciseCommand : IRequest<Unit>
{
    public int ExerciseId { get; init; }

    public int WorkoutId { get; init; }
    public string? Notes { get; init; }
    
    public int? Order { get; init; }
    
    public int? ExerciseDefinitionId { get; init; }
}