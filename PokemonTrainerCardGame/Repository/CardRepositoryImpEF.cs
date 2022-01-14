using PokemonTrainerCardGame.Models;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<CardInfomationPro> OnGetAllCard()
        {
            return (IEnumerable<CardInfomationPro>)_db.CardInfomationPros.ToList();
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
