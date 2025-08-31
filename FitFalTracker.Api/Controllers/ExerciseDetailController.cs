using FitFalTracker.Application.Exercises.Command.CreateExerciseDetail;
using FitFalTracker.Application.Exercises.Queries.GetAllExerciseDetails;
using FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker;
[ApiController]
[Route("api/exerciseDetail")]
public class ExerciseDetailController : BaseController
{
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExerciseDetailVm>> GetExerciseDetails(int id)
    {
        var vm = await Mediator.Send(new GetExerciseDetailQuery() { ExerciseId = id });
        return vm;
    }

    
    [HttpPost("{exerciseId:int}/exerciseDetail")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> CreateExerciseDetail([FromRoute] int exerciseId, [FromBody] CreateExerciseDetailCommand cedc)
    {
        cedc.ExerciseId = exerciseId;
        var id = await Mediator.Send(cedc);
        return CreatedAtAction(nameof(GetExerciseDetails), new { id }, id);
    }

    [HttpGet("allExerciseDetail/{exerciseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AllExerciseDetailForExerciseVm>> GetAllExerciseDetails([FromRoute]int exerciseId)
    {
        var allExercisesDetails = await Mediator.Send(new GetAllExerciseDetailForExerciseQuery(){ExerciseId = exerciseId});
        return allExercisesDetails;
    }
    
}




// private readonly FitFalDbContext _context;
//
// public ExerciseDetailController(FitFalDbContext context)
// {
//     _context = context;
// }

//HttpGet        
// var exerciseDetail = await _context.ExerciseDetails.FirstOrDefaultAsync(e=>e.Id == id);
// return exerciseDetail == null ? NotFound() : Ok(exerciseDetail);

//HttpPost
// var exercise=await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);
// if (exercise == null)
// {
//     return NotFound();
// }
//
// if (exerciseDetail == null)
// {
//     return BadRequest();
// }
//
// exercise.ExerciseDetails.Add(exerciseDetail);
// _context.ExerciseDetails.Add(exerciseDetail);
// await _context.SaveChangesAsync();
// return CreatedAtAction(nameof(GetExerciseDetails), new { id = exerciseDetail.Id }, exerciseDetail);