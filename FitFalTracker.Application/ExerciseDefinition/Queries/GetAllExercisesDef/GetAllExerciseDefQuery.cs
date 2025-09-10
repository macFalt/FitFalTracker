using MediatR;

namespace FitFalTracker.Application.ExerciseDefinition.Queries.GetAllExercisesDef;

public record GetAllExerciseDefQuery() : IRequest<AllExercisesDefVm>
{
    
}