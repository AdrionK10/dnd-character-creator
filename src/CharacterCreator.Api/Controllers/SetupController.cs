using CharacterCreator.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Api.Controllers;

[ApiController]
[Route("api/setup")]
public class SetupController : ControllerBase
{
    private readonly ISetupService _setup;

    public SetupController(ISetupService setup)
    {
        _setup = setup;
    }

    [HttpPost("seed")]
    public async Task<ActionResult<SetupSeedResult>> Seed()
    {
        return Ok(await _setup.SeedPopularReferenceDataAsync());
    }
}
