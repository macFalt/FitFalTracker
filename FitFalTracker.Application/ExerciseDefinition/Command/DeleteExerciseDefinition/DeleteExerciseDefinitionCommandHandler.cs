using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Domain.Exceptions;
using MediatR;

namespace FitFalTracker.Application.ExerciseDefinition.Command.DeleteExerciseDefinition;

public class DeleteExerciseDefinitionCommandHandler : IRequestHandler<DeleteExerciseDefenitionCommand, Unit>
{
    private readonly IFitFalDbContext _context;

    public DeleteExerciseDefinitionCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteExerciseDefenitionCommand request, CancellationToken cancellationToken)
    {
        var exerciseDef=await _context.ExerciseDefinitions
            .FindAsync(new object[]{request.ExerciseDefinitionId});
        
        if(exerciseDef == null)
            throw new NotFoundException(nameof(Domain.Entities.ExerciseDefinition)
                ,("ExerciseDefinitionId",request.ExerciseDefinitionId));
        
        _context.ExerciseDefinitions.Remove(exerciseDef);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}