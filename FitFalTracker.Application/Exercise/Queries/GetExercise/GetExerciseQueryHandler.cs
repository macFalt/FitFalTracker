using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
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
        var exercise = await _context.Exercises.FirstOrDefaultAsync(i=>i.Id==request.ExerciseId, cancellationToken);
        var exerciseVm = _mapper.Map<ExerciseVm>(exercise);
        return exerciseVm;
    }
}