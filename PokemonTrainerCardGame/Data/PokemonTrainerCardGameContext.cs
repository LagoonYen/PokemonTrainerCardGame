using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonTrainerCardGame.Models;

namespace PokemonTrainerCardGame.Data
{
    public class PokemonTrainerCardGameContext : DbContext
    {
        public PokemonTrainerCardGameContext (DbContextOptions<PokemonTrainerCardGameContext> options)
            : base(options)
        {
        }

        public DbSet<PokemonTrainerCardGame.Models.Card> Card { get; set; }
    }
}
