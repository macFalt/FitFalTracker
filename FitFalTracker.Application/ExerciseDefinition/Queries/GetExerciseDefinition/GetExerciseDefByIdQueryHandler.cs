using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.ExerciseDefinition.Queries;

public class GetExerciseDefByIdQueryHandler : IRequestHandler<GetExerciseDefByIdQuery,ExerciseDefinitionVm>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public GetExerciseDefByIdQueryHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async  Task<ExerciseDefinitionVm> Handle(GetExerciseDefByIdQuery request, CancellationToken cancellationToken)
    {
        var exerciseDef=await _context.ExerciseDefinitions
            .AsNoTracking()
            .Where(e=>e.Id == request.ExerciseDefinitionId)
            .ProjectTo<ExerciseDefinitionVm>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);
        
        if (exerciseDef is null)
            throw new NotFoundException(nameof(Domain.Entities.ExerciseDefinition), 
                ("ExerciseDefinitionId",request.ExerciseDefinitionId));
        
        return exerciseDef;
            
    }
}