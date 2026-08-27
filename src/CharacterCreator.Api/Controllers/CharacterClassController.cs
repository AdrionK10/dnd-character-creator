using CharacterCreator.Api.Interfaces;
using CharacterCreator.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterClassController : ControllerBase
{
    private readonly ICharacterClassService _characterClassService;

    public CharacterClassController(ICharacterClassService characterClassService)
    {
        this._characterClassService = characterClassService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CharacterClass>>> GetAll()
    {
        return Ok(await _characterClassService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CharacterClass>> GetById(int id)
    {
        var characterClass = await _characterClassService.GetByIdAsync(id);
        if (characterClass is null)
        {
            return NotFound();
        }

        return Ok(characterClass);
    }

    [HttpPost]
    public async Task<ActionResult<CharacterClass>> CreateAsync(CharacterClass characterClass)
    {
        var result = await _characterClassService.CreateAsync(characterClass);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CharacterClass>> UpdateAsync(int id, CharacterClass characterClass)
    {
        var result = await _characterClassService.UpdateAsync(id, characterClass);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var result = await _characterClassService.DeleteAsync(id);
        return Ok(result);
    }
}
