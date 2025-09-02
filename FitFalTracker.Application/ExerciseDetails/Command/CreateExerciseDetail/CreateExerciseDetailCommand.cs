using AutoMapper;
using FitFalTracker.Application.Common.Mappings;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Domain.ValueObjects;
using MediatR;

namespace FitFalTracker.Application.Exercises.Command.CreateExerciseDetail;

public class CreateExerciseDetailCommand : IRequest<int>, IMapFrom<ExerciseDetail>
{
    public int Id { get; set; }
    public int Reps { get; set; }
    public int SetNumber { get; set; }
    public int? Rir { get; set; }
    public int? Rpe { get; set; }
    public string Tempo { get; set; }
    public Weight Weight { get; set; }
    public int ExerciseId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateExerciseDetailCommand,ExerciseDetail>();
    }
}

