using Dapper;
using Microsoft.Data.SqlClient;
using PokemonTrainerCardGame.Common;
using PokemonTrainerCardGame.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PokemonTrainerCardGame.Repository
{
    public class CardRepositoryImp
    {
        private readonly AppSetting _appSetting;

        public CardRepositoryImp(AppSetting AppSetting)
        {
            _appSetting = AppSetting;
        }

        //搜尋
        public async Task<IEnumerable<CardInformationPro>> OnGetAllCard()
        {
            try
            {
                using var conn = new SqlConnection(_appSetting.GetConnectionString());
                var sql = @"SELECT * FROM CardInfomationPro";
                return await conn.QueryAsync<CardInformationPro>(sql);
                //using (var conn = new SqlConnection(_appSetting.GetConnectionString()))
                //{
                //    var sql = @"SELECT * FROM CardInfomationPro";
                //    return await conn.QueryAsync<CardInfomationPro>(sql);
                //}
            }
            catch
            {
                throw;
            }
        }

        public async Task<CardInformationPro> GetCardInfoById(int id)
        {
            try
            {
                using var conn = new SqlConnection(_appSetting.GetConnectionString());
                var sql = $@"SELECT * FROM CardInfomationPro WHERE Id = {id}";
                return await conn.QueryFirstOrDefaultAsync<CardInformationPro>(sql);
            }
            catch
            {
                throw;
            }
        }

        //新增
        public async Task<int> OnPostInsert(CardInformationPro card)
        {
            try
            {
                using var conn = new SqlConnection(_appSetting.GetConnectionString());
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
                return await conn.ExecuteAsync(sql, para);
            }
            catch
            {
                throw;
            }
        }

        //修改
        public async Task<int> OnPostEdit(CardInformationPro card)
        {
            try
            {
                //(Version, VersionEnvironment, Number, Rank, SpecialRule, Type, TypeDetail, Hp, Name, Attribute, ImgUrl, ReleaseDate, UpdateDate) Values(@Version, @VersionEnvironment, @Number, @Rank, @SpecialRule, @Type, @TypeDetail, @Hp, @Name, @Attribute, @ImgUrl, @ReleaseDate, @UpdateDate)
                using var conn = new SqlConnection(_appSetting.GetConnectionString());
                var sql = $@"UPDATE CardInfomationPro Set Version = @Version, VersionEnvironment = @VersionEnvironment, Number = @Number, Rank = @Rank, SpecialRule = @SpecialRule, Type = @Type, TypeDetail = @TypeDetail, Hp = @Hp, Name = @Name, Attribute = @Attribute, ImgUrl = @ImgUrl, ReleaseDate = @ReleaseDate, UpdateDate = @UpdateDate WHERE Id = @Id;";
                var para = new
                {
                    Id = card.Id,
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
                    UpdateDate = card.UpdateDate
                };
                return await conn.ExecuteAsync(sql, para);
            }
            catch
            {
                throw;
            }
        }

        //刪除
        public async Task<int> OnPostDel(CardInformationPro card)
        {
            try
            {
                using var conn = new SqlConnection(_appSetting.GetConnectionString());

                //定義count 刪除資料 把Count = row更新的資料筆數 回傳Count
                var sql = $@"
                    DECLARE @Count int 
                    DELETE CardInfomationPro WHERE Id = @Id;
                    SET @Count = @@ROWCOUNT
                    RETURN @Count";

                var para = new DynamicParameters();
                para.Add("@Id", card.Id);
                para.Add("@Count",dbType:DbType.Int32,direction:ParameterDirection.ReturnValue);
                await conn.ExecuteAsync(sql, para);
                //var para = new { card.Id };
                return para.Get<int>("@Count");
            }
            catch
            {
                throw;
            }
        }
    }
}
