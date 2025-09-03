using FitFalTracker.Application.Exercise.Queries.GetAllExercise;
using FitFalTracker.Application.Exercise.Queries.GetExercise;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker;
[ApiController]
[Route("api/exercise")]

public class ExerciseController : BaseController
{

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExerciseVm>> GetExerciseById(int id)
    {
        var exercise = await Mediator.Send(new GetExerciseQuery() { ExerciseId = id });
        return Ok(exercise);
    }

    [HttpGet("{workoutId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetAllExercisesForWorkout(int workoutId)
    {
        var exercises = await Mediator.Send(new GetAllExerciseForWorkoutQuery() { WorkoutId = workoutId });
        return Ok(exercises);
    }
   
}