using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.ModelsOfViews;
using PokemonTrainerCardGame.Service;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Pages.RazorPages
{
    public class CardDelProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardDelProModel(CardService cardService)
        {
            _cardService = cardService;
        }

        [BindProperty]
        public CardInformationProViewModel CardInfoDB { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var card = await _cardService.GetCardInfoById(id);
            if (card == null)
            {
                return NotFound();
            }
            CardInfoDB = card;
            return Page();
        }

        public IActionResult OnPostDel([FromForm] CardInformationPro CardInfoDB)
        {
            CardInformationPro NewCardData = CardInfoDB;
            _cardService.OnPostDel(NewCardData);
            return RedirectToPage("./CardIndexPro");
        }
    }
}
