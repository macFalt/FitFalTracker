using FitFalTracker.Application.Common.Interfaces;
using MediatR;

namespace FitFalTracker.Application.ExerciseDefinition.Command.AddNewExerciseDefinition;

public class AddNewExerciseDefinitionCommandHandler : IRequestHandler<AddNewExerciseDefinitionCommand,int>
{
    private readonly IFitFalDbContext _context;

    public AddNewExerciseDefinitionCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(AddNewExerciseDefinitionCommand request, CancellationToken cancellationToken)
    {
        var exerciseDef = new Domain.Entities.ExerciseDefinition
        {
            Name = request.Name,
            Description = request.Description,
            Equipment = request.Equipment,
            MuscleGroup = request.MuscleGroup
        };

        await _context.ExerciseDefinitions.AddAsync(exerciseDef, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return exerciseDef.Id;
    }
}