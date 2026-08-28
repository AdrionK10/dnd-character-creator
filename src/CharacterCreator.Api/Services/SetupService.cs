using CharacterCreator.Api.Interfaces;
using CharacterCreator.Data;
using CharacterCreator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreator.Api.Services;

public class SetupService : ISetupService
{
    private readonly CharacterDbContext _db;

    public SetupService(CharacterDbContext db)
    {
        _db = db;
    }

    public async Task<SetupSeedResult> SeedPopularReferenceDataAsync()
    {
        var existingSpecies = await _db.Species.Select(item => item.Name).ToListAsync();
        var existingClasses = await _db.CharacterClasses.Select(item => item.Name).ToListAsync();
        var existingBackgrounds = await _db.Backgrounds.Select(item => item.Name).ToListAsync();

        var speciesAdded = AddMissing(
            existingSpecies,
            PopularSpecies,
            item => _db.Species.Add(new Species { Name = item.Name, Description = item.Description }));
        var classesAdded = AddMissing(
            existingClasses,
            PopularClasses,
            item => _db.CharacterClasses.Add(new CharacterClass { Name = item.Name, Description = item.Description }));
        var backgroundsAdded = AddMissing(
            existingBackgrounds,
            PopularBackgrounds,
            item => _db.Backgrounds.Add(new Background { Name = item.Name, Description = item.Description }));

        await _db.SaveChangesAsync();

        return new SetupSeedResult
        {
            SpeciesAdded = speciesAdded,
            ClassesAdded = classesAdded,
            BackgroundsAdded = backgroundsAdded,
            SpeciesTotal = await _db.Species.CountAsync(),
            ClassesTotal = await _db.CharacterClasses.CountAsync(),
            BackgroundsTotal = await _db.Backgrounds.CountAsync()
        };
    }

    private static int AddMissing(
        IReadOnlyCollection<string> existingNames,
        IReadOnlyList<(string Name, string Description)> catalog,
        Action<(string Name, string Description)> add)
    {
        var names = new HashSet<string>(existingNames, StringComparer.OrdinalIgnoreCase);
        var added = 0;

        foreach (var item in catalog)
        {
            if (!names.Add(item.Name))
            {
                continue;
            }

            add(item);
            added++;
        }

        return added;
    }

    private static readonly (string Name, string Description)[] PopularSpecies =
    [
        ("Human", "Versatile people found in every land, known for ambition and adaptability."),
        ("Elf", "Long-lived people with keen senses and a close connection to magic."),
        ("Dwarf", "Stout folk famed for craft, endurance, and loyalty to clan."),
        ("Halfling", "Small, lucky people who prize home, food, and good company."),
        ("Dragonborn", "Proud draconic humanoids who carry a breath weapon and a strong sense of honor."),
        ("Gnome", "Small, curious inventors and illusionists with a love of discovery."),
        ("Orc", "Strong, straightforward people with a fierce will to survive."),
        ("Tiefling", "People with infernal heritage, often marked by horns, a tail, and a wary independence."),
        ("Goliath", "Towering folk of the high mountains, competitive and hardy.")
    ];

    private static readonly (string Name, string Description)[] PopularClasses =
    [
        ("Barbarian", "A fierce warrior who channels rage into devastating attacks."),
        ("Bard", "A performer and jack-of-all-trades who weaves magic through art."),
        ("Cleric", "A priest who channels divine power to heal allies and smite foes."),
        ("Druid", "A guardian of nature who shapeshifts and commands the wild."),
        ("Fighter", "A master of weapons and armor, adaptable in any fight."),
        ("Monk", "A martial artist who turns discipline into supernatural skill."),
        ("Paladin", "A sworn champion bound by an oath, mixing steel and holy magic."),
        ("Ranger", "A hunter and tracker equally at home in the wild and on the battlefield."),
        ("Rogue", "A specialist in stealth, skill, and striking from the shadows."),
        ("Sorcerer", "A spellcaster whose magic is inborn rather than studied."),
        ("Warlock", "A caster empowered by a bargain with a mysterious patron."),
        ("Wizard", "A scholar of magic who prepares spells from a carefully kept book.")
    ];

    private static readonly (string Name, string Description)[] PopularBackgrounds =
    [
        ("Acolyte", "Raised in a temple, you know ritual, scripture, and the politics of faith."),
        ("Charlatan", "You make a living on charm, cons, and false identities."),
        ("Criminal", "You know the underworld, fences, and how to stay one step ahead of the law."),
        ("Entertainer", "You live for the crowd—music, stories, or spectacle."),
        ("Folk Hero", "Ordinary people see you as a champion against bullies and tyrants."),
        ("Guild Artisan", "You are a skilled craftsperson with trade contacts in many towns."),
        ("Hermit", "You spent years in seclusion seeking a revelation or inner quiet."),
        ("Noble", "You were born to privilege, protocol, and the weight of a family name."),
        ("Outlander", "You grew up far from cities, living by the land."),
        ("Sage", "Research and forgotten lore are your trade."),
        ("Sailor", "You know ships, storms, and the rough culture of the docks."),
        ("Soldier", "You served in an army or militia and still carry that discipline."),
        ("Urchin", "You survived the streets by wit, speed, and knowing who to trust.")
    ];
}
