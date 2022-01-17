using PokemonTrainerCardGame.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Repository
{
    public interface CardRepository
    {
        //搜尋
        Task<IEnumerable<CardInformationPro>> OnGetAllCard();
        Task<CardInformationPro> GetCardInfoById(int id);

        //新增
        Task OnPostInsert(CardInformationPro card);

        //修改
        Task OnPostEdit(CardInformationPro card);
        //int OnPostEdit(CardInfomationPro card);

        //刪除
        Task OnPostDel(CardInformationPro card);
    }
}
