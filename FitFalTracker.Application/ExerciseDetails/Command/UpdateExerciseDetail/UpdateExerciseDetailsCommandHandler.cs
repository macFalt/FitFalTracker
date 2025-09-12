using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Domain.Exceptions;
using MediatR;

namespace FitFalTracker.Application.ExerciseDetails.Command.UpdateExerciseDetail;

public class UpdateExerciseDetailsCommandHandler : IRequestHandler<UpdateExerciseDetailsCommand, Unit>
{
    private readonly IFitFalDbContext _context;

    public UpdateExerciseDetailsCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdateExerciseDetailsCommand request, CancellationToken cancellationToken)
    {
        var exerciseDetail=await _context.ExerciseDetails.FindAsync(new object[]{request.Id}, cancellationToken);
        if(exerciseDetail is null)
            throw new NotFoundException(nameof(Domain.Entities.ExerciseDetail), 
                ("ExerciseDetailId",request.Id));
        
        exerciseDetail.SetNumber = request.SetNumber;
        exerciseDetail.Rir = request.Rir;
        exerciseDetail.Rpe=request.Rpe;
        exerciseDetail.Tempo=request.Tempo;
        exerciseDetail.Weight = request.Weight;
        exerciseDetail.Reps = request.Reps;
        
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}