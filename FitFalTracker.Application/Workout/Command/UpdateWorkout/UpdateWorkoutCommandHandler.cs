using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exceptions;
using FitFalTracker.Domain.Exceptions;
using MediatR;

namespace FitFalTracker.Application.Workout.Command.UpdateWorkout;

public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand, Unit>
{
    private readonly IFitFalDbContext _context;

    public UpdateWorkoutCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = await _context.Workouts.FindAsync(new object[]{request.Id}, cancellationToken);
        if (workout == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Workout), ("WorkoutId", request.Id));
        }
        
        if (request.Date.HasValue)
            workout.Date = request.Date.Value;
        if (request.Name != null)
            workout.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}