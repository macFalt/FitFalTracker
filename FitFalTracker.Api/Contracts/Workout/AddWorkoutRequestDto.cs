namespace FitFalTracker.Contracts.Workout;

public record AddWorkoutRequestDto
{
    public DateTime Date { get; init; }

    public string  Name { get; init; }

}