using AutoMapper;
using FitFalTracker.Application.Common.Mappings;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Domain.ValueObjects;

namespace FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;

public class ExerciseDetailVm : IMapFrom<ExerciseDetail>
{
    public int Id { get; set; }
    public int Reps { get; set; }
    public int SetNumber { get; set; }
    public int? Rir { get; set; }
    public int? Rpe { get; set; }
    public string Tempo { get; set; }
    public Weight Weight { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExerciseDetail, ExerciseDetailVm>(); // jesli chcemy mapowac wszystko tak zostawiamy. jesli chcemy mapowac poszczegolne pola dodajemy .ForMember
    }
}