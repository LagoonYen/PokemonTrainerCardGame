using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.ModelsOfViews;
using PokemonTrainerCardGame.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Pages.RazorPages
{
    public class CardEditProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardEditProModel(CardService cardService)
        {
            _cardService = cardService;
        }

        [BindProperty]
        public CardInformationProViewModel CardInfoDB { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var card = await _cardService.GetCardInfoById((int)id);
            if (card == null)
            {
                return NotFound();
            }
            CardInfoDB = card;
            return Page();
        }

        public async Task<IActionResult> OnPostEdit([FromForm] CardInformationPro CardInfoDB)
        {
            CardInformationPro NewCardData = CardInfoDB;
            await _cardService.OnPostEdit(NewCardData);
            return RedirectToPage("./CardIndexPro");
        }
    }
}
