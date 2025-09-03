using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Common.Mappings;
using MediatR;

namespace FitFalTracker.Application.Workout.Command.CreateWorkout;

public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IFitFalDbContext _context;

    public CreateWorkoutCommandHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout=_mapper.Map<Domain.Entities.Workout>(request);
        workout.Date = request.Date;
        await _context.Workouts.AddAsync(workout, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return workout.Id;
    }
}