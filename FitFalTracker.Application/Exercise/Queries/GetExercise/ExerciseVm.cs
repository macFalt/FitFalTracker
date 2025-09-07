using AutoMapper;
using FitFalTracker.Application.Common.Mappings;

namespace FitFalTracker.Application.Exercise.Queries.GetExercise;

public record ExerciseVm : IMapFrom<Domain.Entities.Exercise>
{
    public int Id { get; init; }
    public string Notes { get; init; }
    public int Order { get; init; }
    public int WorkoutId { get; init; }
    public int ExerciseDefinitionId { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Exercise, ExerciseVm>();
    }
}