using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exceptions;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Workout.Command.DeleteWorkout;

public class DeleteWorkoutCommandHandler : IRequestHandler<DeleteWorkoutCommand,Unit>
{
    private readonly IFitFalDbContext _context;

    public DeleteWorkoutCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = await _context.Workouts
            .SingleOrDefaultAsync(w=> w.Id == request.WorkoutId, cancellationToken);
        
        if (workout is null)
            throw new NotFoundException(nameof(Domain.Entities.Workout),
                    ("WorkoutId", request.WorkoutId));

         _context.Workouts.Remove(workout);
         await _context.SaveChangesAsync(cancellationToken);
         return Unit.Value;
        
    }
}