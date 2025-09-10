using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.ExerciseDefinition.Queries;
using FitFalTracker.Application.ExerciseDefinition.Queries.GetAllExercisesDef;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Persistance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker;

[ApiController]
[Route("/api/exerciseDefinition")]
public class ExerciseDefinitionController : BaseController
{

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExerciseDefinitionVm>> GetExerciseDefinition(int id,CancellationToken cancellationToken)
    {
        var exerciseDef = await Mediator.Send(new GetExerciseDefByIdQuery() { ExerciseDefinitionId = id }, cancellationToken);
        return Ok(exerciseDef);
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<AllExercisesDefVm>> GetAllExercisesDef(CancellationToken cancellationToken)
    {
        var exercisesDef = await Mediator.Send(new GetAllExerciseDefQuery(),cancellationToken);
        return Ok(exercisesDef);
    }
    
    
    


    
}