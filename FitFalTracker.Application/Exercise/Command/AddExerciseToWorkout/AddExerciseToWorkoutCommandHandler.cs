using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exceptions;
using FitFalTracker.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Exercise.Command.AddExerciseToWorkout;

public class AddExerciseToWorkoutCommandHandler : IRequestHandler<AddExerciseToWorkoutCommand, int>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public AddExerciseToWorkoutCommandHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(AddExerciseToWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout=await _context.Workouts
            .AsNoTracking()
            .AnyAsync(w=>w.Id==request.WorkoutId,cancellationToken);
        if (!workout)
            throw new NotFoundException(nameof(Domain.Entities.Workout), ("WorkoutId",request.WorkoutId));

        var exerciseDef=await _context.ExerciseDefinitions
            .AsNoTracking()
            .AnyAsync(ed=>ed.Id==request.ExerciseDefinitionId,cancellationToken);
        
        if (!exerciseDef)
            throw new NotFoundException(nameof(Domain.Entities.ExerciseDefinition), ("ExerciseDefinitionId",request.ExerciseDefinitionId));
        
        
        var exercise = new Domain.Entities.Exercise()
        {
            Notes = request.Notes,
            Order = request.Order,
            ExerciseDefinitionId = request.ExerciseDefinitionId,
            WorkoutId = request.WorkoutId
        };
        
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync(cancellationToken);
        return exercise.Id;
        
    }
}