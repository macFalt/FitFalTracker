using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exercise.Queries.GetExercise;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercise.Queries.GetAllExercise;

public class GetAllExerciseForWorkoutQueryHandler : IRequestHandler<GetAllExerciseForWorkoutQuery, AllExerciseForWorkoutVm>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public GetAllExerciseForWorkoutQueryHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<AllExerciseForWorkoutVm> Handle(GetAllExerciseForWorkoutQuery request, CancellationToken cancellationToken)
    {
        var exercise=await _context.Exercises.Where(e=>e.WorkoutId==request.WorkoutId)
            .AsNoTracking()
            .OrderBy(i=>i.Id)
            .ProjectTo<ExerciseVm>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var list = new AllExerciseForWorkoutVm()
        {
            Exercises = exercise
        };
        return list;


    }
}



