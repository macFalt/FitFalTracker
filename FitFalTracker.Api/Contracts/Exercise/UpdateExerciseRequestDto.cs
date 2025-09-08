namespace FitFalTracker.Contracts.Exercise;

public record UpdateExerciseRequestDto()
{
    public string? Notes { get; init; }
    
    public int? Order { get; init; }
    
    public int? ExerciseDefinitionId { get; init; }
}