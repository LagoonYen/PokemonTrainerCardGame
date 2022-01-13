using PokemonTrainerCardGame.Models;
using System.Collections.Generic;

namespace PokemonTrainerCardGame.Service
{
    public interface CardService
    {
        IEnumerable<CardInfomationPro> OnGetAllCard();
        int OnPostInsert(CardInfomationPro card);

    }
}
