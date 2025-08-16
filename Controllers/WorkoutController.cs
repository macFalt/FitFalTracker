using FitFalTracker.Domain.Entities;
using FitFalTracker.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker;
[ApiController]
[Route("/api/workout")]
public class WorkoutController : Controller
{
   protected readonly FitFalDbContext _context;

   public WorkoutController(FitFalDbContext context)
   {
      _context = context;
   }

   [HttpGet("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public async Task<IActionResult> GetWorkout(int id)
   {
      var workout = await _context.Workouts.FirstOrDefaultAsync(i => i.Id == id );
      return workout is null ? NotFound() : Ok(workout);
   }

   [HttpPost]
   [ProducesResponseType(StatusCodes.Status201Created)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<IActionResult> AddWorkout([FromBody] Workout workout)
   {
      if (workout == null)
      {
         return BadRequest();
      }
      
      _context.Workouts.Add(workout);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetWorkout), new {id=workout.Id}, workout);
   }
    
    
}