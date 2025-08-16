using FitFalTracker.Domain.Entities;
using FitFalTracker.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker;

[ApiController]
[Route("[controller]")]
public class ExerciseDefinitionController : Controller
{
    protected readonly FitFalDbContext _context;

    public ExerciseDefinitionController(FitFalDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetExerciseDefinition(int id)
    {
        var exerciseDefinition = await _context.ExerciseDefinitions.FirstOrDefaultAsync(e=>e.Id == id);
        return exerciseDefinition == null ? NotFound() : Ok(exerciseDefinition);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateExerciseDefinition([FromBody] ExerciseDefinition exerciseDefinition)
    {
        if (exerciseDefinition == null)
        {
            return BadRequest();
        }

        _context.ExerciseDefinitions.Add(exerciseDefinition);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetExerciseDefinition), new { id = exerciseDefinition.Id }, exerciseDefinition);
    }


    
}