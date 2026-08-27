using CharacterCreator.Api.Interfaces;
using CharacterCreator.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BackgroundController : ControllerBase
{
    private readonly IBackgroundService backgroundService;

    public BackgroundController(IBackgroundService backgroundService)
    {
        this.backgroundService = backgroundService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Background>>> GetAll()
    {
        return Ok(await backgroundService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Background>> GetById(int id)
    {
        var background = await backgroundService.GetByIdAsync(id);
        if (background is null)
        {
            return NotFound();
        }

        return Ok(background);
    }

    [HttpPost]
    public async Task<ActionResult<Background>> CreateAsync(Background background)
    {
        var result = await backgroundService.CreateAsync(background);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Background>> UpdateAsync(int id, Background background)
    {
        var result = await backgroundService.UpdateAsync(id, background);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var result = await backgroundService.DeleteAsync(id);
        return Ok(result);
    }
}
