using PokemonTrainerCardGame.Models;
using PokemonTrainerCardGame.ModelsOfViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Service
{
    public interface CardService
    {
        //搜尋
        Task<IEnumerable<CardInformationProViewModel>> OnGetAllCard();

        Task<CardInformationProViewModel> GetCardInfoById(int id);
        //CardInfomationPro GetCardInfoById(int id);

        //新增
        Task OnPostInsert(CardInformationPro card);
        
        //修改
        Task OnPostEdit(CardInformationPro card);
        //int OnPostEdit(CardInfomationPro card);

        //刪除
        Task OnPostDel(CardInformationPro card);
    }
}
