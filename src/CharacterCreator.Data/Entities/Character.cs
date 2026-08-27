namespace CharacterCreator.Data.Entities;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public string CharacterClass { get; set; } = string.Empty;
    public int Level { get; set; } = 1;
}
