using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PokemonTrainerCardGame.Models;
using System;

namespace PokemonTrainerCardGame.Pages.CardEditTest
{
    public class CardEditProModel : PageModel
    {

        //https://localhost:44307/CardEditTest/CardEditPro
        [BindProperty]
        public CardInfomationPro Sele { get; set; }
        public string Now { get; set; }
        
        public void OnGet()
        {
            //連線資料庫 SELECT FIRST DATA FROM TABLE
            //var card 
            //Sele = card

            Now = DateTime.Now.ToString("HH:mm:ss");
            var card = new CardInfomationPro();
            card.Version = "s8F";
            card.VersionEnvironment = "F";
            card.Number = 1;
            Sele = card;
        }

        public void OnPostEdit([FromForm] CardInfomationPro Sele)
        {
            //var requestt = Request;
            //var result = JsonConvert.SerializeObject(card);
            //var time = Now;
            var cardVersionEnvironment = Sele.VersionEnvironment;
        }

        //[HttpPost("InsertCard")]
        //public int InsertCard([FromForm] CardInfomationPro CardInfomationPro)
        //{

        //    return InsertCard(CardInfomationPro);
        //}


        //[HttpPost("InsertCard")]
        //public int InsertCard([FromForm] CardInfomationPro CardInfomationPro)
        //{
        //    return InsertCard(CardInfomationPro);
        //}




    }
}
