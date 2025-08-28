using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Domain.Entities;
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
        var exercise = await _context.ExerciseDetails.Where(e => e.Id == request.ExerciseId)
            .FirstOrDefaultAsync(cancellationToken);

        var exerciseDetailVm = _mapper.Map<ExerciseDetailVm>(exercise);
        
        return exerciseDetailVm;
    }
}