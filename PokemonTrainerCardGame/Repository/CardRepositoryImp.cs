using Dapper;
using Microsoft.Data.SqlClient;
using PokemonTrainerCardGame.Common;
using PokemonTrainerCardGame.Models;
using System.Collections.Generic;


namespace PokemonTrainerCardGame.Repository
{
    public class CardRepositoryImp : CardRepository
    {
        private readonly AppSetting _appSetting;

        public CardRepositoryImp(AppSetting AppSetting)
        {
            _appSetting = AppSetting;
        }
        public IEnumerable<CardInfomationPro> OnGetAllCard()
        {
            try
            {
                using (var conn = new SqlConnection(_appSetting.GetConnectionString()))
                {
                    var sql = @"SELECT * FROM CardInfomationPro";
                    return conn.Query<CardInfomationPro>(sql);
                }
            }
            catch
            {
                throw;
            }
        }

        public int OnPostInsert(CardInfomationPro card)
        {
            try
            {
                using(var conn = new SqlConnection(_appSetting.GetConnectionString()))
                {
                    var sql = $@"INSERT INTO CardInfomationPro(Version, VersionEnvironment, Number, Rank, SpecialRule, Type, TypeDetail, Hp, Name, Attribute, ImgUrl, ReleaseDate, UpdateDate) Values (@Version, @VersionEnvironment, @Number, @Rank, @SpecialRule, @Type, @TypeDetail, @Hp, @Name, @Attribute, @ImgUrl, @ReleaseDate, @UpdateDate);";
                    var para = new
                    {
                        Version = card.Version,
                        VersionEnvironment = card.VersionEnvironment,
                        Number = card.Number,
                        Rank = card.Rank,
                        SpecialRule = card.SpecialRule,
                        Type = card.Type,
                        TypeDetail = card.TypeDetail,
                        Hp = card.Hp,
                        Name = card.Name,
                        Attribute = card.Attribute,
                        ImgUrl = card.ImgUrl,
                        ReleaseDate = card.ReleaseDate,
                        UpdateDate = card.UpdateDate,
                    };
                    return conn.Execute(sql, para);
                }
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<CardInfomationPro> Search()
        {
            throw new System.NotImplementedException();
        }
    }
}
