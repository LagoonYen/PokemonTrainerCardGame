using System;
using System.Collections.Generic;

#nullable disable

namespace PokemonTrainerCardGame.Models
{
    public partial class CardInfomationPro
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string VersionEnvironment { get; set; }
        public int Number { get; set; }
        public string Rank { get; set; }
        public string SpecialRule { get; set; }
        public string Type { get; set; }
        public string TypeDetail { get; set; }
        public int? Hp { get; set; }
        public string Name { get; set; }
        public string Attribute { get; set; }
        public string ImgUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
