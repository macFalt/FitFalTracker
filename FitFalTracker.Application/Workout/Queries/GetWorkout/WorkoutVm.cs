using AutoMapper;
using FitFalTracker.Application.Common.Mappings;

namespace FitFalTracker.Application.Workout.Queries.GetWorkout;

public class WorkoutVm : IMapFrom<Domain.Entities.Workout>
{
    public int  Id { get; set; }
    
    public DateTime Date { get; set; }

    public string  Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Workout, WorkoutVm>();
    }
}