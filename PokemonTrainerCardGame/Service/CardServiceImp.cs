using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace PokemonTrainerCardGame.Service
{
    public class CardServiceImp : CardService
    {
        private readonly CardRepository _cardRepository;
        public CardServiceImp(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public IEnumerable<CardInfomationPro> OnGetAllCard()
        {
            var cardInfo = _cardRepository.OnGetAllCard();

            return cardInfo;
        }

        public int OnPostInsert(CardInfomationPro card)
        {
            //取得寫入時間
            var Time = DateTime.Now;
            card.ReleaseDate = Time;
            card.UpdateDate = Time;
            
            return _cardRepository.OnPostInsert(card);
        }
    }
}
