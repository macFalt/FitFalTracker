using AutoMapper;
using FitFalTracker.Application.Common.Mappings;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Domain.ValueObjects;
using MediatR;

namespace FitFalTracker.Application.Exercises.Command.CreateExerciseDetail;

public record CreateExerciseDetailCommand : IRequest<int>, IMapFrom<ExerciseDetail>
{

    public int Reps { get; init; }
    public int SetNumber { get; init; }
    public int? Rir { get; init; }
    public int? Rpe { get; init; }
    public string? Tempo { get; init; }
    public Weight? Weight { get; init; }
    public int ExerciseId { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateExerciseDetailCommand,ExerciseDetail>();
    }
}

