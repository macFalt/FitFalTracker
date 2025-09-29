using FitFalTracker.Domain.Enums;
using MediatR;

namespace FitFalTracker.Application.ExerciseDefinition.Command.UpdateExerciseDefinition;

public record UpdateExerciseDefinitionCommand : IRequest<Unit>
{
    public int ExerciseDefinitionId { get; set; }
    
    public string? Name { get; init; }

    public string? Description { get; init; }

    public MuscleGroupEnum? MuscleGroup { get; init; }
    
    public EquipmentEnum? Equipment { get; init; }
}