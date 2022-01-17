using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Service
{
    //記得Interface
    public class CardServiceImp
    {
        private readonly CardRepository _cardRepository;
        public CardServiceImp(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        //搜尋
        public async Task<IEnumerable<CardInformationPro>> OnGetAllCard()
        {
            var cardInfo = await _cardRepository.OnGetAllCard();

            //拿掉IE
            return cardInfo;
        }

        public async Task<CardInformationPro> GetCardInfoById(int id)
        {
            var cardInfo = await _cardRepository.GetCardInfoById(id);
            return cardInfo;
        }

        //新增
        public async Task OnPostInsert(CardInformationPro card)
        {
            //取得寫入時間
            var Time = DateTime.Now;
            card.ReleaseDate = card.UpdateDate = Time;
            await _cardRepository.OnPostInsert(card);
        }

        //修改
        public async Task OnPostEdit(CardInformationPro card)
        {
            var Time = DateTime.Now;
            card.UpdateDate = Time;
            await _cardRepository.OnPostEdit(card);
        }

        //刪除
        public async Task OnPostDel(CardInformationPro card)
        {
            await _cardRepository.OnPostDel(card);
        }
    }
}
