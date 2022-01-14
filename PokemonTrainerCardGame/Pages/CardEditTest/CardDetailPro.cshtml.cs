using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.Service;

namespace PokemonTrainerCardGame.Pages.CardEditTest
{
    public class CardDetailProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardDetailProModel(CardService cardService)
        {
            _cardService = cardService;
        }

        public CardInfomationPro CardInfoDB { get; set; }

        public ActionResult OnGet(int id)
        {
            var  card = _cardService.GetCardInfoById(id);
            CardInfoDB = card;
            return Page();
        }


    }
}
