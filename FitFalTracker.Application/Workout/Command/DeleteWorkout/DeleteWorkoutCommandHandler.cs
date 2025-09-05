using FitFalTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Workout.Command.DeleteWorkout;

public class DeleteWorkoutCommandHandler : IRequestHandler<DeleteWorkoutCommand,bool>
{
    private readonly IFitFalDbContext _context;
    
    public async Task<bool> Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout= await _context.Workouts
            .FirstOrDefaultAsync(i => i.Id == request.WorkoutId, cancellationToken);

        if (workout == null)
        {
            return false;
        }

         _context.Workouts.Remove((workout));
         await _context.SaveChangesAsync(cancellationToken);
         return true;
        
    }
}