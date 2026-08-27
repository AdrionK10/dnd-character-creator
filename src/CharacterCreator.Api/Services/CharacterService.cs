using CharacterCreator.Data;
using CharacterCreator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Api.Services;

public class CharacterService : ICharacterService
{
    private readonly CharacterDbContext _db;

    public CharacterService(CharacterDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<Character>> GetAllAsync()
    {
        return await _db.Characters
            .AsNoTracking()
            .OrderBy(character => character.Name)
            .ToListAsync();
    }

    public async Task<Character?> GetByIdAsync(int id)
    {
        return await _db.Characters
            .AsNoTracking()
            .FirstOrDefaultAsync(character => character.Id == id);
    }
}
