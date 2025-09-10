using MediatR;

namespace FitFalTracker.Application.ExerciseDefinition.Queries;

public record GetExerciseDefByIdQuery : IRequest<ExerciseDefinitionVm>
{
    public int ExerciseDefinitionId { get; init; }
}