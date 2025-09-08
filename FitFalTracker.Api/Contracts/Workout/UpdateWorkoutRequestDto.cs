namespace FitFalTracker.Contracts.Workout;

public record UpdateWorkoutRequestDto()
{
    public string?  Name { get; init; }
    public DateTime? Date { get; init; }
}