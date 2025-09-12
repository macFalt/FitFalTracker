using AutoMapper;
using FitFalTracker.Application.Common.Mappings;

namespace FitFalTracker.Application.Workout.Queries.GetWorkout;

public record WorkoutVm : IMapFrom<Domain.Entities.Workout>
{
    public int  Id { get; init; }
    
    public DateTime Date { get; init; }

    public string  Name { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Workout, WorkoutVm>();
    }
}