using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exceptions;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercise.Command.DeleteExerciseFromWorkout;

public class DeleteExerciseFromWorkoutCommandHandler : IRequestHandler<DeleteExerciseFromWorkoutCommand,Unit>
{
    private readonly IFitFalDbContext _context;

    public DeleteExerciseFromWorkoutCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteExerciseFromWorkoutCommand request, CancellationToken cancellationToken)
    {
        var exercise = await _context.Exercises
            .SingleOrDefaultAsync(e=>e.Id==request.ExerciseId && e.WorkoutId==request.WorkoutId, cancellationToken);
        
        if (exercise is null)
            throw new NotFoundException(nameof(Domain.Entities.Exercise), ("ExerciseId", request.ExerciseId),("WorkoutId",request.WorkoutId));
        
        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}