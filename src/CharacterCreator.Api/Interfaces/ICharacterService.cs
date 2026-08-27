using CharacterCreator.Data.Entities;

namespace CharacterCreator.Api.Interfaces;

public interface ICharacterService
{
    Task<List<Character>> GetAllAsync();
    Task<Character?> GetByIdAsync(int id);
    Task<Character> CreateAsync(Character character);
    Task<Character> UpdateAsync(int id, Character character);
    Task<bool> DeleteAsync(int id);
}
