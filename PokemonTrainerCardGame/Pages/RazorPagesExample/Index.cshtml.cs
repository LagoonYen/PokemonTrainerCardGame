using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PokemonTrainerCardGame.Data;
using PokemonTrainerCardGame.Models;

namespace PokemonTrainerCardGame.Pages.CardEdit
{
    public class IndexModel : PageModel
    {
        private readonly PokemonTrainerCardGame.Data.PokemonTrainerCardGameContext _context;

        public IndexModel(PokemonTrainerCardGame.Data.PokemonTrainerCardGameContext context)
        {
            _context = context;
        }

        public IList<Card> Card { get;set; }

        public async Task OnGetAsync()
        {
            Card = await _context.Card.ToListAsync();
        }
    }
}
