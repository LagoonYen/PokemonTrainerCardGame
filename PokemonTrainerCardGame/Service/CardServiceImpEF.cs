using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.ModelsOfViews;
using PokemonTrainerCardGame.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<CardInformationProViewModel>> OnGetAllCard()
        {
            var cardInfo = await _cardRepository.OnGetAllCard();
            return cardInfo.OrderBy(x => x.Version)
                .ThenBy(x => x.Number)
                .Select(x => new CardInformationProViewModel
                {
                    Id = x.Id,
                    Version = x.Version,
                    VersionEnvironment = x.VersionEnvironment,
                    Number = x.Number,
                    Rank = x.Rank,
                    SpecialRule = x.SpecialRule,
                    Type = x.Type,
                    TypeDetail = x.TypeDetail,
                    Hp = x.Hp,
                    Name = x.Name,
                    Attribute = x.Attribute,
                    ImgUrl = x.ImgUrl,
                    ReleaseDate = x.ReleaseDate.ToString("yyyy/MM/dd"),
                    UpdateDate = x.UpdateDate.ToString("yyyy/MM/dd"),
                });
        }

        public async Task<CardInformationProViewModel> GetCardInfoById(int id)
        {
            var cardInfo = await _cardRepository.GetCardInfoById(id);
            
            return new CardInformationProViewModel
            {
                Id = cardInfo.Id,
                Version = cardInfo.Version,
                VersionEnvironment = cardInfo.VersionEnvironment,
                Number = cardInfo.Number,
                Rank = cardInfo.Rank,
                SpecialRule = cardInfo.SpecialRule,
                Type = cardInfo.Type,
                TypeDetail = cardInfo.TypeDetail,
                Hp = cardInfo.Hp,
                Name = cardInfo.Name,
                Attribute = cardInfo.Attribute,
                ImgUrl = cardInfo.ImgUrl,
                ReleaseDate = cardInfo.ReleaseDate.ToString("g"),
                UpdateDate = cardInfo.UpdateDate.ToString("g"),
            };
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
