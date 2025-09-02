using System.Windows.Input;
using FitFalTracker.Application.Common.Mappings;
using FitFalTracker.Domain.Entities;
using MediatR;

namespace FitFalTracker.Application.Exercises.Command.DeleteExerciseDetail;

public class DeleteExerciseDetailCommand : IRequest<bool>
{
    public int ExerciseDetailId { get; set; }
    public int ExerciseId  { get; set; }
}