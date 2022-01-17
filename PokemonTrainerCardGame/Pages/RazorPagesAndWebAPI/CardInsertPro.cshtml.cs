using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.Service;
using System.Collections.Generic;

namespace PokemonTrainerCardGame.Pages.RazorPagesAndWebAPI
{
    public class CardInsertProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardInsertProModel(CardService cardService)
        {
            _cardService = cardService;
        }

        [BindProperty]
        public CardInformationPro CardInfoDB { get; set; }

        //public IEnumerable<CardInfomationPro> sele { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPostInsert([FromForm] CardInformationPro CardInfoDB)
        {
            CardInformationPro NewCardData = CardInfoDB;
            _cardService.OnPostInsert(NewCardData);
            return RedirectToPage("./CardIndexPro");
        }



    }
}
