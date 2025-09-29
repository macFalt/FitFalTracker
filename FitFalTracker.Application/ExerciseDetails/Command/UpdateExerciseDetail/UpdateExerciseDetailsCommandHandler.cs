using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exceptions;
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
        var exerciseDetail = await _context.ExerciseDetails.FindAsync(new object[] { request.Id }, cancellationToken);
        if (exerciseDetail is null)
            throw new NotFoundException(nameof(Domain.Entities.ExerciseDetail),
                ("ExerciseDetailId", request.Id));

        if (request.SetNumber.HasValue && request.SetNumber != exerciseDetail.SetNumber)
            exerciseDetail.SetNumber = request.SetNumber.Value;

        if (request.Rir.HasValue && request.Rir != exerciseDetail.Rir)
            exerciseDetail.Rir = request.Rir;

        if (request.Rpe.HasValue && request.Rpe != exerciseDetail.Rpe)
            exerciseDetail.Rpe = request.Rpe;

        if (request.Tempo is not null && request.Tempo != exerciseDetail.Tempo)
            exerciseDetail.Tempo = request.Tempo;

        if (request.Weight is not null && request.Weight != exerciseDetail.Weight)
            exerciseDetail.Weight = request.Weight;

        if (request.Reps.HasValue && request.Reps != exerciseDetail.Reps)
            exerciseDetail.Reps = request.Reps.Value;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}