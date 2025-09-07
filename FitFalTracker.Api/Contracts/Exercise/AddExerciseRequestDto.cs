namespace FitFalTracker.Contracts.Exercise;

public record AddExerciseRequestDto
{
    public string Notes { get; init; }
    public int Order { get; init; }
    public int WorkoutId { get; init; }
    public int ExerciseDefinitionId { get; init; }
}