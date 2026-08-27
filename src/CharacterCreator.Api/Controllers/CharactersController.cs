using CharacterCreator.Api.Services;
using CharacterCreator.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly ICharacterService _characters;

    public CharactersController(ICharacterService characters)
    {
        _characters = characters;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Character>>> GetAll()
    {
        return Ok(await _characters.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Character>> GetById(int id)
    {
        var character = await _characters.GetByIdAsync(id);
        if (character is null)
        {
            return NotFound();
        }

        return Ok(character);
    }
}
