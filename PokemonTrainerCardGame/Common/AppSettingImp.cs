using Microsoft.Extensions.Configuration;

namespace PokemonTrainerCardGame.Common
{
    public class AppSettingImp : AppSetting
    {
        private readonly IConfiguration _configuration;
        public AppSettingImp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        {
            return _configuration.GetValue<string>("ConnectionStrings:PTCGDB");
        }
    }
}
