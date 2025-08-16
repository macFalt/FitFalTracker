using FitFalTracker.Domain.Entities;
using FitFalTracker.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FitFalTracker;
[ApiController]
[Route("[controller]")]
public class EnumController : Controller
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetEquipment()
    {
        var items = Enum.GetValues<EquipmentEnum>()
            .Select(e => new
            {
                Id = e,
                Name = e.ToString(),
            });
        return Ok(items);


    }
}