using FitFalTracker.Domain.Enums;

namespace FitFalTracker.Contracts.ExerciseDefinition;

public record AddExerciseDefinitionRequestDto
{
    public string Name { get; init; }

    public string Description { get; init; }

    public string MuscleGroup { get; init; }
    
    public EquipmentEnum Equipment { get; init; }
}