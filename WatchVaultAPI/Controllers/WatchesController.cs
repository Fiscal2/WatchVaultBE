using Microsoft.AspNetCore.Mvc;
using WatchVaultAPI.Interfaces;

namespace WatchVaultAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchesController : ControllerBase
{
    private readonly IWatchService _watchService;

    public WatchesController(IWatchService watchService)
    {
        _watchService = watchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] string? brand)
    {
        var watches = await _watchService.GetAllAsync(search, brand);
        return Ok(watches);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var watch = await _watchService.GetByIdAsync(id);

        if (watch is null)
        {
            return NotFound();
        }

        return Ok(watch);
    }
}