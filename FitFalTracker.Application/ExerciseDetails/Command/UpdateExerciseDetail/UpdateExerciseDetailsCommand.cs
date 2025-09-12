using FitFalTracker.Domain.ValueObjects;
using MediatR;

namespace FitFalTracker.Application.ExerciseDetails.Command.UpdateExerciseDetail;

public record UpdateExerciseDetailsCommand : IRequest<Unit>
{
    public int Id { get; init; }
    public int Reps { get; init; }
    public int SetNumber { get; init; }
    public int? Rir { get; init; }
    public int? Rpe { get; init; }
    public string? Tempo { get; init; }
    public Weight? Weight { get; init; }}