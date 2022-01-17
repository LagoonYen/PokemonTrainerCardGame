using Microsoft.EntityFrameworkCore;
using PokemonTrainerCardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Repository
{
    public class CardRepositoryImpEF : CardRepository
    {
        private readonly PTCGWebApplicationContext _db;

        public CardRepositoryImpEF(PTCGWebApplicationContext dbContext)
        {
            _db = dbContext;
        }

        //搜尋
        public async Task<IEnumerable<CardInformationPro>> OnGetAllCard()
        {
            return await _db.CardInfomationPros.ToListAsync();
        }

        public async Task<CardInformationPro> GetCardInfoById(int id)
        {
            return await _db.CardInfomationPros.FindAsync(id);
        }

        //新增
        public async Task OnPostInsert(CardInformationPro card)
        {
            await _db.AddAsync(card);
            await _db.SaveChangesAsync();
        }

        //修改
        public async Task OnPostEdit(CardInformationPro card)
        {
            try
            {
                var cardInfo = await _db.CardInfomationPros.FindAsync(card.Id);
                if (cardInfo == null)
                {
                    throw new Exception("找不到該筆資料!");
                }
                cardInfo = card;
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw;  
            }
                
        }

        //刪除
        public async Task OnPostDel(CardInformationPro card)
        {
            try
            {
                var cardInfo = await _db.CardInfomationPros.FindAsync(card.Id);
                if(cardInfo == null)
                {
                    throw new Exception("找不到該筆資料!");
                }
                //找不到RemoveAsync
                _db.CardInfomationPros.Remove(cardInfo);
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
