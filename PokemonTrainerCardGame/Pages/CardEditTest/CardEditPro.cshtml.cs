using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Pages.CardEditTest
{
    public class CardEditProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardEditProModel(CardService cardService)
        {
            _cardService = cardService;
        }

        [BindProperty]
        public CardInfomationPro CardInfoDB { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var card = _cardService.GetCardInfoById(id);
            if (card == null)
            {
                return NotFound();
            }
            CardInfoDB = card;
            return Page();
        }

        public IActionResult OnPostEdit([FromForm] CardInfomationPro CardInfoDB)
        {
            CardInfomationPro NewCardData = CardInfoDB;
            _cardService.OnPostEdit(NewCardData);
            return RedirectToPage("./CardIndexPro");
        }
    }
}
