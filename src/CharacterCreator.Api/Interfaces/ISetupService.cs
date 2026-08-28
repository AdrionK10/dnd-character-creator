namespace CharacterCreator.Api.Interfaces;

public interface ISetupService
{
    Task<SetupSeedResult> SeedPopularReferenceDataAsync();
}

public class SetupSeedResult
{
    public int SpeciesAdded { get; set; }
    public int ClassesAdded { get; set; }
    public int BackgroundsAdded { get; set; }
    public int SpeciesTotal { get; set; }
    public int ClassesTotal { get; set; }
    public int BackgroundsTotal { get; set; }
}
