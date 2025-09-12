using AutoMapper;
using FitFalTracker.Application.Common.Mappings;

namespace FitFalTracker.Application.ExerciseDefinition.Queries.GetAllExercisesDef;

public record AllExercisesDefVm() 
{
    public ICollection<ExerciseDefinitionVm> ExercisesDef { get; init; }
    
}