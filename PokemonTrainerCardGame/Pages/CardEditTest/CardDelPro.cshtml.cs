using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.Service;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Pages.CardEditTest
{
    public class CardDelProModel : PageModel
    {
        private readonly CardService _cardService;

        public CardDelProModel(CardService cardService)
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

        public IActionResult OnPostDel([FromForm] CardInfomationPro CardInfoDB)
        {
            CardInfomationPro NewCardData = CardInfoDB;
            _cardService.OnPostDel(NewCardData);
            return RedirectToPage("./CardIndexPro");
        }
    }
}
