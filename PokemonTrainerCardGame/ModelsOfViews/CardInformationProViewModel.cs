namespace PokemonTrainerCardGame.ModelsOfViews
{
    public class CardInformationProViewModel
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
        public string ReleaseDate { get; set; }
        public string UpdateDate { get; set; }
    }
}
