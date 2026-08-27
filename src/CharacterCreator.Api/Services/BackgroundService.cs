using CharacterCreator.Api.Interfaces;
using CharacterCreator.Data;
using CharacterCreator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Api.Services;

public class BackgroundService : IBackgroundService
{
    private readonly CharacterDbContext _db;

    public BackgroundService(CharacterDbContext db)
    {
        _db = db;
    }

    public async Task<List<Background>> GetAllAsync()
    {
        var Backgrounds = await _db.Backgrounds.OrderBy(x => x.Name).ToListAsync();
        return Backgrounds;
    }
   
    public async Task<Background?> GetByIdAsync(int id)
    {
        return await _db.Backgrounds.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Background> CreateAsync(Background Background)
    {
        _db.Backgrounds.Add(Background);
        await _db.SaveChangesAsync();
        return Background;
    }

    public async Task<Background> UpdateAsync(int id, Background Background)
    {
        var entity = await _db.Backgrounds.FirstOrDefaultAsync(x => x.Id == id);
        entity.Name = Background.Name;
        entity.Description = Background.Description;
        await _db.SaveChangesAsync();
        return Background;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var found = await GetByIdAsync(id);
        if (found == null) return false;
        _db.Backgrounds.Remove(found);
        await _db.SaveChangesAsync();
        return true;

    }
}
