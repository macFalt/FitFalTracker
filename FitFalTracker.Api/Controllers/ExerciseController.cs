using FitFalTracker.Domain.Entities;
using FitFalTracker.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker;
[ApiController]
[Route("[controller]")]

public class ExerciseController : Controller
{
    private readonly FitFalDbContext _context;

    public ExerciseController(FitFalDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetExercise(int id)
    {
        var exercise = _context.Exercises.FirstOrDefault(e => e.Id == id);
        return exercise == null ? NotFound() : Ok(exercise);
    }
    
    
    [HttpPost("{workoutId:int}/exercise")]
    public async Task<IActionResult> AddExercise(int workoutId, [FromBody] Exercise exercise)
    {
        var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == workoutId);
        if (workout is null)
        {
            return NotFound();
        }

        exercise.WorkoutId = workoutId;
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetExercise), new { id = workout.Id }, workout);
    }
}