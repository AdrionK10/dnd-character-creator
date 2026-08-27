using CharacterCreator.Api.Interfaces;
using CharacterCreator.Data;
using CharacterCreator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Api.Services;

public class SpeciesService : ISpeciesService
{
    private readonly CharacterDbContext _db;

    public SpeciesService(CharacterDbContext db)
    {
        _db = db;
    }

    public async Task<List<Species>> GetAllAsync()
    {
        var Speciess = await _db.Species.OrderBy(x => x.Name).ToListAsync();
        return Speciess;
    }
   
    public async Task<Species?> GetByIdAsync(int id)
    {
        return await _db.Species.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Species> CreateAsync(Species Species)
    {
        _db.Species.Add(Species);
        await _db.SaveChangesAsync();
        return Species;
    }

    public async Task<Species> UpdateAsync(int id, Species Species)
    {
        var entity = await _db.Species.FirstOrDefaultAsync(x => x.Id == id);
        entity.Name = Species.Name;
        entity.Description = Species.Description;
        await _db.SaveChangesAsync();
        return Species;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await GetByIdAsync(id);
        if (found == null) return false;
        _db.Species.Remove(found);
        await _db.SaveChangesAsync();
        return true;

    }
}
