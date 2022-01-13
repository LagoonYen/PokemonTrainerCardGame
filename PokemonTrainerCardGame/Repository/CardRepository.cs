using PokemonTrainerCardGame.Models;
using System.Collections.Generic;

namespace PokemonTrainerCardGame.Repository
{
    public interface CardRepository
    {
        IEnumerable<CardInfomationPro> Search();
        IEnumerable<CardInfomationPro> OnGetAllCard();
        int OnPostInsert(CardInfomationPro card);
    }
}
