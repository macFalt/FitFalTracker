using FitFalTracker.Domain.Entities;
using FitFalTracker.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker;
[Route("api/user")]
[ApiController]
public class UserController : Controller
{
    private readonly FitFalDbContext _context;

    public UserController(FitFalDbContext context)
    {
        _context = context;
    }

    // GET /api/users/1
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(AppUser), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]   
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _context.AppUsers.AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);

        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUser([FromBody] AppUser user)
    {
        if (user is null) return BadRequest();
        _context.AppUsers.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        
    }
    

}