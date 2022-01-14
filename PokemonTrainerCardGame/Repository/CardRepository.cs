using PokemonTrainerCardGame.Models;
using System.Collections.Generic;

namespace PokemonTrainerCardGame.Repository
{
    public interface CardRepository
    {
        //搜尋
        IEnumerable<CardInfomationPro> OnGetAllCard();
        CardInfomationPro GetCardInfoById(int id);
        IEnumerable<CardInfomationPro> Search(); //未用到

        //新增
        int OnPostInsert(CardInfomationPro card);

        //修改
        int OnPostEdit(CardInfomationPro card);

        //刪除
        int OnPostDel(CardInfomationPro card);
    }
}
