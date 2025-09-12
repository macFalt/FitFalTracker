using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.ExerciseDefinition.Queries.GetAllExercisesDef;

public class GetAllExerciseDefQueryHandler : IRequestHandler<GetAllExerciseDefQuery, AllExercisesDefVm>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public GetAllExerciseDefQueryHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AllExercisesDefVm> Handle(GetAllExerciseDefQuery request, CancellationToken cancellationToken)
    {
        var exercisesDef = await _context.ExerciseDefinitions
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .ProjectTo<ExerciseDefinitionVm>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        var vm = new AllExercisesDefVm()
        {
            ExercisesDef = exercisesDef
        };

        return vm;
    }
}