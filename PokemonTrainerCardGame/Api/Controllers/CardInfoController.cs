using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.ModelsOfViews;
using PokemonTrainerCardGame.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardInfoController : ControllerBase
    {
        private readonly CardRepository _cardRepository;
        /// <summary>
        /// DI注入
        /// </summary>
        /// <param name="cardRepository"></param>
        public CardInfoController(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        /// <summary>
        /// 查詢所有卡片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        //標示該方法的回傳格式
        [Produces("application/json")]
        //指定回傳時的型別
        [ProducesResponseType(typeof(CardInformationProViewModel), 200)]
        [Route("GetAllCard")]
        public async Task<IEnumerable<CardInformationProViewModel>> GetAllCard()
        {
            var cardInfo = await _cardRepository.OnGetAllCard();

            var d = cardInfo.OrderBy(x => x.Version)
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
            return d;
        }

        /// <summary>
        /// 查詢單一卡片
        /// </summary>
        /// <remarks>以ID查詢卡片完整資訊</remarks>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        /// <response code = "200"> 回傳對應的卡片 </response>
        /// <response code = "404"> 找不到該編號的卡片 </response>  
        [HttpGet]
        [Route("GetAllCard/{id}")]
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

        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("OnPostInsert")]
        public async Task OnPostInsert(CardInformationPro card)
        {
            //取得寫入時間
            var Time = DateTime.Now;
            card.ReleaseDate = card.UpdateDate = Time;
            await _cardRepository.OnPostInsert(card);
        }

        /// <summary>
        /// 修改單一卡片資訊
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        [Route("OnPostEdit")]
        public async Task OnPostEdit(CardInformationPro card)
        {
            var Time = DateTime.Now;
            card.UpdateDate = Time;
            await _cardRepository.OnPostEdit(card);
        }

        /// <summary>
        /// 刪除單一卡片資訊
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("OnPostDel")]
        public async Task OnPostDel(CardInformationPro card)
        {
            await _cardRepository.OnPostDel(card);
        }

        /// <summary>
        /// 演示[Obsolete]
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [Route("Example")]
        public async Task ExampleForObsolete(CardInformationPro card)
        {
            await _cardRepository.OnGetAllCard();
        }
    }
}
