using CharacterCreator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Data;

public class CharacterDbContext : DbContext
{
    public CharacterDbContext(DbContextOptions<CharacterDbContext> options)
        : base(options)
    {
    }

    public DbSet<Character> Characters => Set<Character>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.Property(character => character.Name).HasMaxLength(100).IsRequired();
            entity.Property(character => character.Race).HasMaxLength(50).IsRequired();
            entity.Property(character => character.CharacterClass).HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<Character>().HasData(
            new Character
            {
                Id = 1,
                Name = "Sample Character",
                Race = "Human",
                CharacterClass = "Fighter",
                Level = 1
            });
    }
}
