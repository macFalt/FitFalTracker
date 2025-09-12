using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;

public class GetExerciseDetailQueryHandler : IRequestHandler<GetExerciseDetailQuery,ExerciseDetailVm>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public GetExerciseDetailQueryHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    
    public async  Task<ExerciseDetailVm> Handle(GetExerciseDetailQuery request, CancellationToken cancellationToken)
    {
        var exercise = await _context.ExerciseDetails
            .AsNoTracking()
            .Where(ed => ed.Id == request.ExerciseDetailId && ed.ExerciseId == request.ExerciseId)
            .ProjectTo<ExerciseDetailVm>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (exercise is null)
            throw new NotFoundException(nameof(Domain.Entities.ExerciseDetail),
                ("ExerciseDetailId", request.ExerciseDetailId),
                ("ExerciseId", request.ExerciseId));
        
        return exercise;
    }
}