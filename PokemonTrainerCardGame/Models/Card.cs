using System;

namespace PokemonTrainerCardGame.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string VersionEnviroment { get; set; }
        public int Number { get; set; }
        public string Rank { get; set; }
        public string SpecialRule { get; set; }
        public string Type { get; set; }
        public string TypeDetail { get; set; }
        public int HP { get; set; }
        public string Name { get; set; }
        public string Attribute { get; set; }
        public string ImgSrc { get; set; }
        public DateTime CreatTime { get; set; }
        public DateTime UpdateTime { get; set; }
        
    }
}
