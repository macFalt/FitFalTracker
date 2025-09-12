using AutoMapper;
using FitFalTracker.Application.Common.Mappings;
using MediatR;

namespace FitFalTracker.Application.Workout.Command.CreateWorkout;

public record CreateWorkoutCommand : IRequest<int>
{
    public DateTime Date { get; init; }

    public string  Name { get; init; }
    
}