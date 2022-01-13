using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainerCardGame.Pages.CardEditTest
{
    public class CardIndexProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardIndexProModel(CardService cardService)
        {
            _cardService = cardService;
        }

        public IEnumerable<CardInfomationPro> CardInfoDB { get; set; }

        public void OnGet()
        {
            IEnumerable<CardInfomationPro> card = _cardService.OnGetAllCard();

            card.OrderBy(x => x.Version)
                .ThenBy(x => x.Number)
                .Select(x => new CardInfomationPro
                {
                    Version = x.Version,
                    VersionEnvironment = x.VersionEnvironment,
                    Number = x.Number,
                    Rank = x.Rank,
                    SpecialRule = x.SpecialRule,
                    Type = x.Type,
                    TypeDetail = x.TypeDetail,
                    Hp = x.Hp,
                    Name = x.Name,
                    Attribute = x.Attribute,
                    ImgUrl = x.ImgUrl,
                    ReleaseDate = x.ReleaseDate,
                    UpdateDate = x.UpdateDate,
                });
            CardInfoDB = card;
        }

        
    }
}
