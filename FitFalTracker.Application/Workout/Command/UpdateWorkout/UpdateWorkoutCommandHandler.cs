using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
using MediatR;

namespace FitFalTracker.Application.Workout.Command.UpdateWorkout;

public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand, UpdateWorkoutDTO>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public UpdateWorkoutCommandHandler(IFitFalDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<UpdateWorkoutDTO> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = await _context.Workouts.FindAsync(request.Id,cancellationToken);
        if (workout == null)
        {
            throw new KeyNotFoundException("Not Found");
        }
        
        if (request.Date.HasValue)
            workout.Date = request.Date.Value;
        if (request.Name != null)
            workout.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UpdateWorkoutDTO>(workout);
    }
}