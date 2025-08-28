using AutoMapper;
using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;
using FitFalTracker.Domain.Entities;
using MediatR;

namespace FitFalTracker.Application.Exercises.Command.CreateExerciseDetail;

public class CreateExerciseDetailCommandHandler : IRequestHandler<CreateExerciseDetailCommand, int>
{
    private readonly IFitFalDbContext _context;
    private readonly IMapper _mapper;

    public CreateExerciseDetailCommandHandler(IFitFalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<int> Handle(CreateExerciseDetailCommand request, CancellationToken cancellationToken)
    {
        var exerciseDetail = _mapper.Map<ExerciseDetail>(request);
        _context.ExerciseDetails.Add(exerciseDetail);
        await _context.SaveChangesAsync(cancellationToken);
        return exerciseDetail.Id;
    }
    
}