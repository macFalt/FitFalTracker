using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exceptions;
using FitFalTracker.Domain.Exceptions;
using MediatR;

namespace FitFalTracker.Application.ExerciseDefinition.Command.UpdateExerciseDefinition;

public class UpdateExerciseDefinitionCommandHandler : IRequestHandler<UpdateExerciseDefinitionCommand, Unit>
{
    private readonly IFitFalDbContext _context;

    public UpdateExerciseDefinitionCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdateExerciseDefinitionCommand request, CancellationToken cancellationToken)
    {
        var exerciseDef= await _context.ExerciseDefinitions
            .FindAsync(new object[]{request.ExerciseDefinitionId}, cancellationToken);
        
        if (exerciseDef == null)
            throw new NotFoundException(nameof(Domain.Entities.ExerciseDefinition),
                ("ExerciseDefinitionID",request.ExerciseDefinitionId));
        
        exerciseDef.Description = request.Description;
        
        if (request.MuscleGroup.HasValue)
            exerciseDef.MuscleGroup = request.MuscleGroup.Value;
        
        if (request.Equipment.HasValue)
            exerciseDef.Equipment = request.Equipment.Value;
        
        exerciseDef.Name = request.Name;
        
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
        
    }
}