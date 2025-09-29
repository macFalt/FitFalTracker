using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exceptions;
using FitFalTracker.Domain.Exceptions;
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

        var workout = await _context.Workouts
            .AsNoTracking()
            .Where(w => w.Id == request.WorkoutId)
            .ProjectTo<WorkoutVm>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (workout is null)
            throw new NotFoundException(nameof(Domain.Entities.Workout), ("Workout", request.WorkoutId));

        return workout;

    }
}