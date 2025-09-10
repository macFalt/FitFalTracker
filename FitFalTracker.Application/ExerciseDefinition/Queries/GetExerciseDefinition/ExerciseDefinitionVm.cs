using AutoMapper;
using FitFalTracker.Application.Common.Mappings;
using FitFalTracker.Domain.Enums;

namespace FitFalTracker.Application.ExerciseDefinition.Queries;

public class ExerciseDefinitionVm : IMapFrom<Domain.Entities.ExerciseDefinition>
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public string MuscleGroup { get; init; }
    
    public EquipmentEnum Equipment { get; init; }

    public void Mapper(Profile profile)
    {
        profile.CreateMap<Domain.Entities.ExerciseDefinition, ExerciseDefinitionVm>();
        
    }
}