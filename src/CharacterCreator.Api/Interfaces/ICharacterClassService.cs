using CharacterCreator.Data.Entities;

namespace CharacterCreator.Api.Interfaces;

public interface ICharacterClassService
{
    Task<List<CharacterClass>> GetAllAsync();
    Task<CharacterClass?> GetByIdAsync(int id);
    Task<CharacterClass> CreateAsync(CharacterClass characterClass);
    Task<CharacterClass> UpdateAsync(int id, CharacterClass characterClass);
    Task<bool> DeleteAsync(int id);
}
