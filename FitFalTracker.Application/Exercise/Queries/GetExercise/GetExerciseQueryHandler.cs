using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercise.Queries.GetExercise;

public class GetExerciseQueryHandler : IRequestHandler<GetExerciseQuery, ExerciseVm>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public GetExerciseQueryHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ExerciseVm> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
    {
        var exercise = await _context.Exercises
            .AsNoTracking()
            .Where(i => i.Id == request.ExerciseId && i.WorkoutId == request.WorkoutId)
            .ProjectTo<ExerciseVm>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);
        if(exercise is null)
            throw new NotFoundException(nameof(Domain.Entities.Exercise),
                ("ExerciseId", request.ExerciseId),
                ("WorkoutId", request.WorkoutId));
        
        return exercise;




    }
}