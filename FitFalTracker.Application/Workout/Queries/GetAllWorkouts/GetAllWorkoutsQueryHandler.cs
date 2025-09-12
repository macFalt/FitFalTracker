using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Workout.Queries.GetWorkout;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Workout.Queries.GetAllWorkout;

public class GetAllWorkoutsQueryHandler : IRequestHandler<GetAllWorkoutsQuery, AllWorkoutVm>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public GetAllWorkoutsQueryHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<AllWorkoutVm> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
    {
        var workouts=await _context.Workouts
            .AsNoTracking()
            .OrderBy(i => i.Id)
            .ProjectTo<WorkoutVm>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var list = new AllWorkoutVm()
        {
            Workouts = workouts
        };
        return list;

    }
}