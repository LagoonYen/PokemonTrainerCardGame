using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.Service;
using System.Collections.Generic;

namespace PokemonTrainerCardGame.Pages.CardEditTest
{
    public class CardInsertProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardInsertProModel(CardService cardService)
        {
            _cardService = cardService;
        }

        [BindProperty]
        public CardInfomationPro CardInfoDB { get; set; }

        //public IEnumerable<CardInfomationPro> sele { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPostInsert([FromForm] CardInfomationPro CardInfoDB)
        {
            CardInfomationPro NewCardData = CardInfoDB;
            _cardService.OnPostInsert(NewCardData);
            return RedirectToPage("./CardIndexPro");
        }



    }
}
