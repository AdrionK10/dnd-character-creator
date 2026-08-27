using CharacterCreator.Data.Entities;

namespace CharacterCreator.Api.Services;

public interface ICharacterService
{
    Task<IReadOnlyList<Character>> GetAllAsync();
    Task<Character?> GetByIdAsync(int id);
}
