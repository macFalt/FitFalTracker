using FitFalTracker.Application.Exercise.Command.AddExerciseToWorkout;
using FitFalTracker.Application.Exercise.Queries.GetAllExercise;
using FitFalTracker.Application.Exercise.Queries.GetExercise;
using FitFalTracker.Application.Workout.Command.CreateWorkout;
using FitFalTracker.Application.Workout.Command.DeleteWorkout;
using FitFalTracker.Application.Workout.Command.UpdateWorkout;
using FitFalTracker.Application.Workout.Queries.GetAllWorkout;
using FitFalTracker.Application.Workout.Queries.GetWorkout;
using FitFalTracker.Contracts.Exercise;
using FitFalTracker.Contracts.Workout;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CreatedIdDto = FitFalTracker.Contracts.Exercise.CreatedIdDto;

namespace FitFalTracker;

[ApiController]
[Route("/api/workout")]
public class WorkoutController : BaseController
{
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WorkoutVm>> GetWorkoutById(int id)
    {
        var workout=await Mediator.Send(new GetWorkoutQuery() { WorkoutId = id });
        return Ok(workout);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AllWorkoutVm>> GetAllWorkout()
    {
        var workouts = await Mediator.Send(new GetAllWorkoutsQuery());
        return Ok(workouts);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreatedIdDto>> CreateWorkout([FromBody] AddWorkoutRequestDto request)
    {
        var cmd = new CreateWorkoutCommand()
        {
            Name = request.Name,
            Date = DateTime.Now
        };
        
        var workout= await Mediator.Send(cmd);
        return CreatedAtAction(
            nameof(GetWorkoutById),
            new {id=workout},
            new CreatedIdDto { Id = workout });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DelateWorkout(int id)
    {
        var deleted= await Mediator.Send(new DeleteWorkoutCommand() { WorkoutId = id });
        return NoContent();
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateWorkout(int id,[FromBody] UpdateWorkoutCommand command)
    {
        try
        {
            var update= await Mediator.Send(new UpdateWorkoutCommand(id,command.Date,command.Name));
            return NoContent();

        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        
    }
    
    
    //************************Exercise******************

    [HttpGet("{id}/exercise/{exerciseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExerciseVm>> GetExerciseById(int id, int exerciseId)
    {
        var exercise= await Mediator.Send(new GetExerciseQuery(){ExerciseId = exerciseId, WorkoutId = id });
        return Ok(exercise);
    }

    [HttpGet("{id}/exercise/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AllExerciseForWorkoutVm>> GetAllExerciseByWorkoutId(int id)
    {
        var exercises= await Mediator.Send(new GetAllExerciseForWorkoutQuery(){WorkoutId = id});
        return Ok(exercises);
    }

    [HttpPost("{workoutId}/exercise")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CreatedIdDto>> AddExercise(int workoutId, AddExerciseRequestDto request)
    {
        var cmd = new AddExerciseToWorkoutCommand()
        {
            Notes = request.Notes,
            Order = request.Order,
            WorkoutId = workoutId,
            ExerciseDefinitionId = request.ExerciseDefinitionId
        };
        
        var created = await Mediator.Send(cmd);
        return CreatedAtAction(
            nameof(GetExerciseById),
            new { id = workoutId, exerciseId = created },
            new CreatedIdDto{Id = created});


    }
        
        


}