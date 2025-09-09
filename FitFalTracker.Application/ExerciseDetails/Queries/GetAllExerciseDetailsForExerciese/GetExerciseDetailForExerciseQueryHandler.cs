using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;
using FitFalTracker.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercises.Queries.GetAllExerciseDetails;

public class GetAllExerciseDetailForExerciseQueryHandler : IRequestHandler<GetAllExerciseDetailForExerciseQuery, AllExerciseDetailForExerciseVm>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public GetAllExerciseDetailForExerciseQueryHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<AllExerciseDetailForExerciseVm> Handle(GetAllExerciseDetailForExerciseQuery request, CancellationToken cancellationToken)
    {
        var allExercises =await _context.ExerciseDetails
            .Where(id=>id.ExerciseId == request.ExerciseId)
            .AsNoTracking()
            .OrderBy(i=>i.Id)
            .ProjectTo<ExerciseDetailVm>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);


        var list = new AllExerciseDetailForExerciseVm()
        {
            ExerciseDetails = allExercises
        };
        return list;

    }
}