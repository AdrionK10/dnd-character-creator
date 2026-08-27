using CharacterCreator.Api.Interfaces;
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

    public async Task<List<Character>> GetAllAsync()
    {
        var characters = await _db.Characters.OrderBy(x => x.Name).ToListAsync();
        return characters;
    }
   
    public async Task<Character?> GetByIdAsync(int id)
    {
        return await _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Character> CreateAsync(Character character)
    {
        _db.Characters.Add(character);
        await _db.SaveChangesAsync();
        return character;
    }

    public async Task<Character> UpdateAsync(int id, Character character)
    {
        var entity = await _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
        entity.Name = character.Name;
        entity.BackgroundId = character.BackgroundId;
        entity.CharacterImage = character.CharacterImage;
        entity.ClassId = character.ClassId;
        entity.SpeciesId = character.SpeciesId;
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await GetByIdAsync(id);
        if (found == null) return false;
        _db.Characters.Remove(found);
        await _db.SaveChangesAsync();
        return true;

    }
}
