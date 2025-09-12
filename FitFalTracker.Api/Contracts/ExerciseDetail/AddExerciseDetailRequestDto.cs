using FitFalTracker.Domain.ValueObjects;

namespace FitFalTracker.Contracts.ExerciseDetail;

public record AddExerciseDetailRequestDto
{
    public int Reps { get; init; }
    public int SetNumber { get; init; }
    public int? Rir { get; init; }
    public int? Rpe { get; init; }
    public string? Tempo { get; init; }
    public Weight? Weight { get; init; }
}