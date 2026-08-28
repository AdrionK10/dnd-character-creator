namespace CharacterCreator.Web.Models;


    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //Id comes from background table
        public int SpeciesId { get; set; } 
        //Id comes from background table
        public int ClassId { get; set; }
        //Id comes from background table
        public int BackgroundId { get; set; }
        public byte[] CharacterImage { get; set; } = Array.Empty<byte>();
    }

    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    public class Background
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    
    public class CharacterClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }