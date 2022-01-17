using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.ModelsOfViews;
using PokemonTrainerCardGame.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Pages.RazorPagesAndWebAPI
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
            //ªÅ
        }
    }
}
