using CharacterCreator.Api.Interfaces;
using CharacterCreator.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpeciesController : ControllerBase
{
    private readonly ISpeciesService _speciesService;

    public SpeciesController(ISpeciesService speciesService)
    {
        this._speciesService = speciesService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Species>>> GetAll()
    {
        return Ok(await _speciesService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Species>> GetById(int id)
    {
        var species = await _speciesService.GetByIdAsync(id);
        if (species is null)
        {
            return NotFound();
        }

        return Ok(species);
    }

    [HttpPost]
    public async Task<ActionResult<Species>> CreateAsync(Species species)
    {
        var result = await _speciesService.CreateAsync(species);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Species>> UpdateAsync(int id, Species species)
    {
        var result = await _speciesService.UpdateAsync(id, species);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var result = await _speciesService.DeleteAsync(id);
        return Ok(result);
    }
}
