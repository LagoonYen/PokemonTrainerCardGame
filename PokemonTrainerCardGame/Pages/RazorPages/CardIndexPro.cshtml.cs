using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.ModelsOfViews;
using PokemonTrainerCardGame.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Pages.RazorPages
{
    public class CardIndexProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardIndexProModel(CardService cardService)
        {
            _cardService = cardService;
        }

        public IEnumerable<CardInformationProViewModel> CardInfoDB { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var card = await _cardService.OnGetAllCard();

            if (!string.IsNullOrEmpty(SearchString))
            {
                if (SearchString.Contains(" "))
                {
                    var spliteSearchString = SearchString.Split(" ");
                    for (var i = 0; i < spliteSearchString.Length; i++)
                    {
                        var Keywords = spliteSearchString[i];
                        //card = card.Where(x => x.Name.Contains(Keywords) || x.Version.Contains(Keywords) || x.VersionEnvironment.Contains(Keywords));
                        card = card.Where(x => new[] { x.Name, x.Version, x.VersionEnvironment }.Any(x => x.Contains(Keywords)));
                    }
                }
                else
                {
                    card = card.Where(x => x.Name.Contains(SearchString));
                }
            }
            CardInfoDB = card;
        }
    }
}
