using CharacterCreator.Data.Entities;

namespace CharacterCreator.Api.Interfaces;

public interface IBackgroundService
{
    Task<List<Background>> GetAllAsync();
    Task<Background?> GetByIdAsync(int id);
    Task<Background> CreateAsync(Background background);
    Task<Background> UpdateAsync(int id, Background background);
    Task<bool> DeleteAsync(int id);
}
