using AutoMapper;
using FitFalTracker.Application.Common.Mappings;

namespace FitFalTracker.Application.Workout.Command.UpdateWorkout;

public sealed record UpdateWorkoutDTO(int Id,DateTime Date, string Name) : IMapFrom<Domain.Entities.Workout>
{
    public UpdateWorkoutDTO() : this(default, default, string.Empty) { }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Workout, UpdateWorkoutDTO>();
    }
}