using System;
using System.Collections.Generic;

#nullable disable

namespace PokemonTrainerCardGame.Models
{
    public partial class CardInfomation
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public int VersionEnvironment { get; set; }
        public int Number { get; set; }
        public int Rank { get; set; }
        public int? SpecialRule { get; set; }
        public int Type { get; set; }
        public int TypeDetail { get; set; }
        public string Name { get; set; }
        public int Attributes { get; set; }
        public string ImgUrl { get; set; }
    }
}
