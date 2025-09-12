using FitFalTracker.Application.Common.Interfaces;
using FitFalTracker.Application.ExerciseDefinition.Command.AddNewExerciseDefinition;
using FitFalTracker.Application.ExerciseDefinition.Command.DeleteExerciseDefinition;
using FitFalTracker.Application.ExerciseDefinition.Command.UpdateExerciseDefinition;
using FitFalTracker.Application.ExerciseDefinition.Queries;
using FitFalTracker.Application.ExerciseDefinition.Queries.GetAllExercisesDef;
using FitFalTracker.Contracts.ExerciseDefinition;
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
    public async Task<ActionResult<ExerciseDefinitionVm>> GetExerciseDefinitionById(int id,CancellationToken cancellationToken)
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateExerciseDefinitionIdDto>> AddExerciseDefinition(
        [FromBody] AddExerciseDefinitionRequestDto request, CancellationToken cancellationToken)
    {
        var cmd = new AddNewExerciseDefinitionCommand()
        {
            Name = request.Name,
            Description = request.Description,
            Equipment = request.Equipment,
            MuscleGroup = request.MuscleGroup
        };
        var exerciseDefId=await Mediator.Send(cmd, cancellationToken);
        return CreatedAtAction(
            nameof(GetExerciseDefinitionById),
            new {id=exerciseDefId},
            new CreateExerciseDefinitionIdDto() { Id = exerciseDefId });    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteExerciseDefinition(int id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteExerciseDefenitionCommand(){ExerciseDefinitionId = id}, cancellationToken);
        return NoContent();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateExerciseDefinition(int id,
        [FromBody] UpdateExerciseDefinitionRequestDto request, CancellationToken cancellationToken)
    {
        var cmd = new UpdateExerciseDefinitionCommand()
        {
            ExerciseDefinitionId = id,
            Description = request.Description,
            MuscleGroup = request.MuscleGroup,
            Equipment = request.Equipment,
            Name = request.Name
        };
        await Mediator.Send(cmd, cancellationToken);
        return NoContent();
    }
    
    


    
}