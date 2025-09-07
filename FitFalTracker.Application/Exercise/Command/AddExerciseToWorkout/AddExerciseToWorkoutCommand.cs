using AutoMapper;
using FitFalTracker.Application.Common.Mappings;
using FitFalTracker.Domain.Entities;
using MediatR;

namespace FitFalTracker.Application.Exercise.Command.AddExerciseToWorkout;

public record AddExerciseToWorkoutCommand : IRequest<int>
{
    public string Notes { get; init; }
    public int Order { get; init; }
    public int WorkoutId { get; init; }
    public int ExerciseDefinitionId { get; init; }
    
}