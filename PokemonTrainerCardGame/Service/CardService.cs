using PokemonTrainerCardGame.Models;
using System.Collections.Generic;

namespace PokemonTrainerCardGame.Service
{
    public interface CardService
    {
        //搜尋
        IEnumerable<CardInfomationPro> OnGetAllCard();
        CardInfomationPro GetCardInfoById(int id);
        IEnumerable<CardInfomationPro> Search();

        //新增
        int OnPostInsert(CardInfomationPro card);
        
        //修改
        int OnPostEdit(CardInfomationPro card);
        
        //刪除
        int OnPostDel(CardInfomationPro card);
    }
}
