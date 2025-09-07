using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Common.Mappings;
using MediatR;

namespace FitFalTracker.Application.Workout.Command.CreateWorkout;

public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, int>
{
    private readonly IFitFalDbContext _context;

    public CreateWorkoutCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = new Domain.Entities.Workout()
        {
            Name = request.Name,
            Date = request.Date,
        };
        
        await _context.Workouts.AddAsync(workout, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return workout.Id;
    }
}