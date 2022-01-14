﻿using PokemonTrainerCardGame.Models;
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

        //搜尋
        public IEnumerable<CardInfomationPro> OnGetAllCard()
        {
            var cardInfo = _cardRepository.OnGetAllCard();

            return cardInfo;
        }
        public CardInfomationPro GetCardInfoById(int id)
        {
            var cardInfo = _cardRepository.GetCardInfoById(id);

            return cardInfo;
        }

        public IEnumerable<CardInfomationPro> Search()
        {
            throw new NotImplementedException();
        }

        //新增
        public int OnPostInsert(CardInfomationPro card)
        {
            //取得寫入時間
            var Time = DateTime.Now;
            card.ReleaseDate = card.UpdateDate = Time;
            return _cardRepository.OnPostInsert(card);
        }

        //修改
        public int OnPostEdit(CardInfomationPro card)
        {
            var Time = DateTime.Now;
            card.UpdateDate = Time;
            return _cardRepository.OnPostEdit(card);
        }

        //刪除
        public int OnPostDel(CardInfomationPro card)
        {
            return _cardRepository.OnPostDel(card);
        }
    }
}
