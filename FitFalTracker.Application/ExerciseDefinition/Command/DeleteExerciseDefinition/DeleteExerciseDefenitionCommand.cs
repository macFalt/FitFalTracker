using MediatR;

namespace FitFalTracker.Application.ExerciseDefinition.Command.DeleteExerciseDefinition;

public record DeleteExerciseDefenitionCommand : IRequest<Unit>
{
    public int ExerciseDefinitionId { get; init; }
}