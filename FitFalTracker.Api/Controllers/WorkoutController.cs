using FitFalTracker.Application.Exercise.Command.AddExerciseToWorkout;
using FitFalTracker.Application.Exercise.Command.DeleteExerciseFromWorkout;
using FitFalTracker.Application.Exercise.Command.UpdateExercise;
using FitFalTracker.Application.Exercise.Queries.GetAllExercise;
using FitFalTracker.Application.Exercise.Queries.GetExercise;
using FitFalTracker.Application.Exercises.Command.CreateExerciseDetail;
using FitFalTracker.Application.Exercises.Command.DeleteExerciseDetail;
using FitFalTracker.Application.Exercises.Queries.GetAllExerciseDetails;
using FitFalTracker.Application.Exercises.Queries.GetExerciseDetail;
using FitFalTracker.Application.Workout.Command.CreateWorkout;
using FitFalTracker.Application.Workout.Command.DeleteWorkout;
using FitFalTracker.Application.Workout.Command.UpdateWorkout;
using FitFalTracker.Application.Workout.Queries.GetAllWorkout;
using FitFalTracker.Application.Workout.Queries.GetWorkout;
using FitFalTracker.Contracts.Exercise;
using FitFalTracker.Contracts.ExerciseDetail;
using FitFalTracker.Contracts.Workout;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<CreatedExerciseIdDto>> CreateWorkout([FromBody] AddWorkoutRequestDto request)
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
            new CreatedExerciseIdDto { Id = workout });
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
    public async Task<ActionResult> UpdateWorkout(int id,[FromBody] UpdateWorkoutRequestDto command, CancellationToken cancellationToken)
    {
        var uw = new UpdateWorkoutCommand()
        {
            Id = id,
            Name = command.Name,
            Date = command.Date
        };
        
        await Mediator.Send(uw,cancellationToken);
        return NoContent();
    }
    
    
    //************************Exercise******************

    [HttpGet("{id}/exercise/{exerciseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExerciseVm>> GetExerciseById(int id, int exerciseId,CancellationToken cancellationToken)
    {
        var exercise= await Mediator.Send(new GetExerciseQuery(){ExerciseId = exerciseId, WorkoutId = id }, cancellationToken);
        return Ok(exercise);
    }

    [HttpGet("{id}/exercises")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AllExerciseForWorkoutVm>> GetAllExerciseByWorkoutId(int id,CancellationToken cancellationToken)
    {
        var exercises= await Mediator.Send(new GetAllExerciseForWorkoutQuery(){WorkoutId = id},cancellationToken);
        return Ok(exercises);
    }

    [HttpPost("{workoutId}/exercise")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CreatedExerciseIdDto>> AddExercise(int workoutId, [FromBody]AddExerciseRequestDto request, CancellationToken cancellationToken)
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
            new CreatedExerciseIdDto{Id = created});
    }

    [HttpDelete("{workoutId}/exercise/{exerciseId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteExerciseFromWorkout(int workoutId, int exerciseId,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteExerciseFromWorkoutCommand() { WorkoutId = workoutId,ExerciseId=exerciseId},cancellationToken);
        return NoContent();
    }

    [HttpPatch("{workoutId}/exercise/{exerciseId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateExercise(int workoutId, int exerciseId,
        [FromBody] UpdateExerciseRequestDto request, CancellationToken cancellationToken)
    {
        var exercise = new UpdateExerciseCommand()
        {
            Notes = request.Notes,
            Order = request.Order,
            ExerciseDefinitionId = request.ExerciseDefinitionId,
            WorkoutId = workoutId,
            ExerciseId = exerciseId

        };
        
        await Mediator.Send(exercise,cancellationToken);
        return NoContent();

    }
    
    //************************ExerciseDetail******************

    [HttpGet("{workoutId}/exercise/{exerciseId}/exercisedetail/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExerciseDetailVm>> GetExerciseDetailFromExerciseById
    (int workoutId, int exerciseId,int id, CancellationToken cancellationToken)
    {
        var exerciseDetail = await Mediator.Send(new GetExerciseDetailQuery()
            { ExerciseDetailId = id, ExerciseId = exerciseId },cancellationToken);

        return Ok(exerciseDetail);
    }

    [HttpGet("{workoutId}/exercise/exerciseDetails")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AllExerciseDetailForExerciseVm>> GetAllExerciseDetailFromExercise
        (int exerciseId, CancellationToken cancellationToken)
    {
        var exerciseDetails =
            await Mediator.Send(new GetAllExerciseDetailForExerciseQuery() 
                { ExerciseId = exerciseId },cancellationToken);
        return Ok(exerciseDetails);
    }

    [HttpPost("{workoutId}/exercises/{exerciseId}/exerciseDetails")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CreateExerciseDetailIdRequestDto>> AddExerciseDetails
    (int workoutId, int exerciseId,
        [FromBody] AddExerciseDetailRequestDto request, CancellationToken cancellationToken)
    {
        var exerciseD = new CreateExerciseDetailCommand()
        {
            ExerciseId = exerciseId,
            Reps = request.Reps,
            Rir = request.Rir,
            Rpe = request.Rpe,
            SetNumber = request.SetNumber,
            Tempo = request.Tempo,
            Weight = request.Weight
        };
        
        var createdId= await Mediator.Send(exerciseD, cancellationToken);
        
        return CreatedAtAction(
            nameof(GetExerciseDetailFromExerciseById),
            new { workoutId, exerciseId, id = createdId },
            new CreatedIdDto { Id = createdId });
    }

    [HttpDelete("{workoutId}/exercises/{exerciseId}/details/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteExerciseDetailFromExerciseById(int id,int workoutId,int exerciseId,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteExerciseDetailCommand(){ExerciseDetailId = id, ExerciseId = exerciseId},cancellationToken);
        return NoContent();
    }
    
    
        
        


}