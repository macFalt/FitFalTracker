using AutoMapper;
using FitFalTracker.Application.Common.Mappings;
using MediatR;

namespace FitFalTracker.Application.Workout.Command.CreateWorkout;

public class CreateWorkoutCommand : IRequest<int>, IMapFrom<Domain.Entities.Workout>
{
    public int  Id { get; set; }
    
    public DateTime Date { get; set; }

    public string  Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateWorkoutCommand, Domain.Entities.Workout>();
    }
}