using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PokemonTrainerCardGame.Data;
using PokemonTrainerCardGame.Models;

namespace PokemonTrainerCardGame.Pages.CardEdit
{
    public class CreateModel : PageModel
    {
        private readonly PokemonTrainerCardGame.Data.PokemonTrainerCardGameContext _context;

        public CreateModel(PokemonTrainerCardGame.Data.PokemonTrainerCardGameContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Card Card { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Card.Add(Card);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
