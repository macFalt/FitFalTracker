using AutoMapper;
using FitFalTracker.Application.Common.Mappings;

namespace FitFalTracker.Application.Exercise.Queries.GetExercise;

public class ExerciseVm : IMapFrom<Domain.Entities.Exercise>
{
    public int Id { get; set; }
    public string Notes { get; set; }
    public int Order { get; set; }
    public int WorkoutId { get; set; }
    public int ExerciseDefinitionId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Exercise, ExerciseVm>();
    }
}