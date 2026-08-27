using CharacterCreator.Data.Entities;

namespace CharacterCreator.Api.Interfaces;

public interface ISpeciesService
{
    Task<List<Species>> GetAllAsync();
    Task<Species?> GetByIdAsync(int id);
    Task<Species> CreateAsync(Species species);
    Task<Species> UpdateAsync(int id, Species species);
    Task<bool> DeleteAsync(int id);
}
