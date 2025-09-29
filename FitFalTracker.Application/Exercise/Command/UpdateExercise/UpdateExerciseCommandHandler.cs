using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exceptions;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercise.Command.UpdateExercise;

public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand,Unit>
{
    private readonly IFitFalDbContext _context;

    public UpdateExerciseCommandHandler(IFitFalDbContext context)
    {
        _context = context;
        
    }
    public async Task<Unit> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise=await _context.Exercises
            .SingleOrDefaultAsync(e=>e.Id==request.ExerciseId && e.WorkoutId==request.WorkoutId,cancellationToken);
        
        if(exercise is null)
            throw new NotFoundException(nameof(Domain.Entities.Exercise), 
                ("ExerciseId", request.ExerciseId),
                ("WorkoutId", request.WorkoutId));
        
        if (request.Notes != null)
            exercise.Notes = request.Notes;
        if (request.Order.HasValue)
            exercise.Order = request.Order.Value;
        if (request.ExerciseDefinitionId.HasValue)
            exercise.ExerciseDefinitionId = request.ExerciseDefinitionId.Value;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}