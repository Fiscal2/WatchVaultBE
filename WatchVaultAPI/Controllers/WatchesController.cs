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
    public async Task<IActionResult> GetAll()
    {
        var watches = await _watchService.GetAllAsync();
        return Ok(watches);
    }
}