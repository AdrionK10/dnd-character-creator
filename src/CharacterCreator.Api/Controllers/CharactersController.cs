using CharacterCreator.Api.Interfaces;
using CharacterCreator.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService characterService;

    public CharacterController(ICharacterService characterService)
    {
        this.characterService = characterService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetAll()
    {
        return Ok(await characterService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Character>> GetById(int id)
    {
        var character = await characterService.GetByIdAsync(id);
        if (character is null)
        {
            return NotFound();
        }

        return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<Character>> CreateAsync(Character character)
    {
        var result = await characterService.CreateAsync(character);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Character>> UpdateAsync(int id, Character character)
    {
        var result = await characterService.UpdateAsync(id, character);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var result = await characterService.DeleteAsync(id);
        return Ok(result);
    }
}
