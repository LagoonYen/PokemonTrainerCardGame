using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.ModelsOfViews;
using PokemonTrainerCardGame.Service;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Pages.RazorPages
{
    public class CardDetailProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardDetailProModel(CardService cardService)
        {
            _cardService = cardService;
        }

        public CardInformationProViewModel CardInfoDB { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var  card = await _cardService.GetCardInfoById(id);
            CardInfoDB = card;
            return Page();
        }


    }
}
