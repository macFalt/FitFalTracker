using AutoMapper;
using FitFalTracker.Application.Common.Mappings;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Domain.ValueObjects;

namespace FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;

public record ExerciseDetailVm : IMapFrom<ExerciseDetail>
{
    public int Id { get; init; }
    public int Reps { get; init; }
    public int SetNumber { get; init; }
    public int? Rir { get; init; }
    public int? Rpe { get; init; }
    public string? Tempo { get; init; }
    public Weight Weight { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExerciseDetail, ExerciseDetailVm>(); // jesli chcemy mapowac wszystko tak zostawiamy. jesli chcemy mapowac poszczegolne pola dodajemy .ForMember
    }
}