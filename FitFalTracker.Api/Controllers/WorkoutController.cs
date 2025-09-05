using FitFalTracker.Application.Exercise.Queries.GetExercise;
using FitFalTracker.Application.Workout.Command.CreateWorkout;
using FitFalTracker.Application.Workout.Command.DeleteWorkout;
using FitFalTracker.Application.Workout.Queries.GetAllWorkout;
using FitFalTracker.Application.Workout.Queries.GetWorkout;
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
    public async Task<ActionResult<WorkoutVm>> CreateWorkout(CreateWorkoutCommand command)
    {
        var workout= await Mediator.Send(command);
        return Ok(workout);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DelateWorkout(int id)
    {
        var deleted= await Mediator.Send(new DeleteWorkoutCommand() { WorkoutId = id });
        return deleted ? NoContent() : NotFound();
    }



}