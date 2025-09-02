using FitFalTracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercises.Command.DeleteExerciseDetail;

public class DeleteExerciseDetailCommandHandler : IRequestHandler<DeleteExerciseDetailCommand,bool>
{
    private readonly IFitFalDbContext _context;

    public DeleteExerciseDetailCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }


    public async Task<bool> Handle(DeleteExerciseDetailCommand request, CancellationToken cancellationToken)
    {
        var exerciseDetail = await _context.ExerciseDetails.FirstOrDefaultAsync(e => e.Id == request.ExerciseDetailId
            && e.ExerciseId == request.ExerciseId, cancellationToken: cancellationToken);
        if (exerciseDetail == null)
        {
            return false;
        }

        _context.ExerciseDetails.Remove(exerciseDetail);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}