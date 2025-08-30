using FitFalTracker.Domain.Entities;
using FitFalTracker.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FitFalTracker;
[ApiController]
[Route("[controller]")]
public class EnumController : Controller
{
    [HttpGet("equipments")]
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

    [HttpGet("heightUnit")]
    public IActionResult GetHeightUnit()
    {
        var items = Enum.GetValues<HeightEnum>()
            .Select(h => new
            {
                Id = h,
                Name = h.ToString(),
            });
        return Ok(items);
    }

    [HttpGet("weightUnit")]
    public IActionResult GetWeightUnit()
    {
        var items = Enum.GetValues<WeightEnum>()
            .Select(w => new
            {
                Id = w,
                Name = w.ToString(),
            });
        return Ok(items);
    }
}