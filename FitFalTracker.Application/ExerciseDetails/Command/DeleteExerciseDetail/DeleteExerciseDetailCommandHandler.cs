using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercises.Command.DeleteExerciseDetail;

public class DeleteExerciseDetailCommandHandler : IRequestHandler<DeleteExerciseDetailCommand,Unit>
{
    private readonly IFitFalDbContext _context;

    public DeleteExerciseDetailCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }


    public async Task<Unit> Handle(DeleteExerciseDetailCommand request, CancellationToken cancellationToken)
    {
        var exerciseDetail = await _context.ExerciseDetails
            .FindAsync(new object[] { request.ExerciseDetailId }, cancellationToken);
        
        if (exerciseDetail is null)
            throw new NotFoundException(nameof(Domain.Entities.ExerciseDetail), 
                ("ExerciseDetailId",request.ExerciseDetailId));
        
        _context.ExerciseDetails.Remove(exerciseDetail);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
        

        
    }
}