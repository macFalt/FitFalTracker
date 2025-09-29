using AutoMapper;
using FitFalTracker.Application.Common.Mappings;
using FitFalTracker.Domain.Enums;
using MediatR;

namespace FitFalTracker.Application.ExerciseDefinition.Command.AddNewExerciseDefinition;

public record AddNewExerciseDefinitionCommand : IRequest<int>
{
    
    public string Name { get; init; }

    public string? Description { get; init; }

    public MuscleGroupEnum MuscleGroup { get; init; }
    
    public EquipmentEnum Equipment { get; init; }

}