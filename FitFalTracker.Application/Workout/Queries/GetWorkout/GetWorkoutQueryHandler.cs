using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Workout.Queries.GetWorkout;

public class GetWorkoutQueryHandler : IRequestHandler<GetWorkoutQuery, WorkoutVm>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public GetWorkoutQueryHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    
    public async Task<WorkoutVm> Handle(GetWorkoutQuery request, CancellationToken cancellationToken)
    {
        var workout=await _context.Workouts.FirstOrDefaultAsync(w=>w.Id == request.WorkoutId,cancellationToken);
        var workoutVm=_mapper.Map<WorkoutVm>(workout);
        return workoutVm;
    }
}