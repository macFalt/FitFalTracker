using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exceptions;
using FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercises.Command.CreateExerciseDetail;

public class CreateExerciseDetailCommandHandler : IRequestHandler<CreateExerciseDetailCommand, int>
{
    private readonly IFitFalDbContext _context;

    public CreateExerciseDetailCommandHandler(IFitFalDbContext context)
    {
        _context = context;
    }


    public async Task<int> Handle(CreateExerciseDetailCommand request, CancellationToken cancellationToken)
    {
        var exerciseExists = await _context.Exercises
            .AsNoTracking()
            .AnyAsync(e => e.Id == request.ExerciseId,cancellationToken);

        if (!exerciseExists)
            throw new NotFoundException(nameof(Domain.Entities.Exercise),
                ("ExerciseId", request.ExerciseId));

        var exerciseDetail = new ExerciseDetail()
        {
            ExerciseId = request.ExerciseId,
            Reps = request.Reps,
            SetNumber = request.SetNumber,
            Rir = request.Rir,
            Rpe = request.Rpe,
            Tempo = request.Tempo,
            Weight = request.Weight
        };

        _context.ExerciseDetails.Add(exerciseDetail);
        await _context.SaveChangesAsync(cancellationToken);
        return exerciseDetail.Id;

    }
    
}