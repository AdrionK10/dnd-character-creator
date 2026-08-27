using CharacterCreator.Api.Interfaces;
using CharacterCreator.Data;
using CharacterCreator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Api.Services;

public class CharacterClassService : ICharacterClassService
{
    private readonly CharacterDbContext _db;

    public CharacterClassService(CharacterDbContext db)
    {
        _db = db;
    }

    public async Task<List<CharacterClass>> GetAllAsync()
    {
        var CharacterClasss = await _db.CharacterClasses.OrderBy(x => x.Name).ToListAsync();
        return CharacterClasss;
    }
   
    public async Task<CharacterClass?> GetByIdAsync(int id)
    {
        return await _db.CharacterClasses.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<CharacterClass> CreateAsync(CharacterClass CharacterClass)
    {
        _db.CharacterClasses.Add(CharacterClass);
        await _db.SaveChangesAsync();
        return CharacterClass;
    }

    public async Task<CharacterClass> UpdateAsync(int id, CharacterClass CharacterClass)
    {
        var entity = await _db.CharacterClasses.FirstOrDefaultAsync(x => x.Id == id);
        entity.Name = CharacterClass.Name;
        entity.Description = CharacterClass.Description;
        await _db.SaveChangesAsync();
        return CharacterClass;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await GetByIdAsync(id);
        if (found == null) return false;
        _db.CharacterClasses.Remove(found);
        await _db.SaveChangesAsync();
        return true;

    }
}
