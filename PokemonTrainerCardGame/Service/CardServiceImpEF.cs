using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.Repository;
using System.Collections.Generic;

namespace PokemonTrainerCardGame.Service
{
    public class CardServiceImpEF : CardService
    {
        private readonly CardRepository _cardRepository;
        public CardServiceImpEF(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        //搜尋
        public IEnumerable<CardInfomationPro> OnGetAllCard()
        {
            var cardInfo = _cardRepository.OnGetAllCard();

            return cardInfo;
        }

        public CardInfomationPro GetCardInfoById(int id)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<CardInfomationPro> Search()
        {
            throw new System.NotImplementedException();
        }

        //新增
        public int OnPostInsert(CardInfomationPro card)
        {
            throw new System.NotImplementedException();
        }

        //修改
        public int OnPostEdit(CardInfomationPro card)
        {
            throw new System.NotImplementedException();
        }

        //刪除
        public int OnPostDel(CardInfomationPro card)
        {
            throw new System.NotImplementedException();
        }
    }
}
