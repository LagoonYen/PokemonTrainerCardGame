using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonTrainerCardGame.Data;
using PokemonTrainerCardGame.Service;
using PokemonTrainerCardGame.Repository;
using PokemonTrainerCardGame.Common;
using PokemonTrainerCardGame.Models;

namespace PokemonTrainerCardGame
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<PokemonTrainerCardGameContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PokemonTrainerCardGameContext")));
            //services.AddDbContext<PokemonTrainerCardGameContext>(options =>
                    //options.UseSqlServer(Configuration.GetConnectionString("PTCGDB")));
            //services.AddScoped<CardService, CardServiceImp>();
            services.AddScoped<CardService, CardServiceImpEF>();
            //services.AddScoped<CardRepository, CardRepositoryImp>();
            services.AddScoped<CardRepository, CardRepositoryImpEF>();
            services.AddScoped<AppSetting, AppSettingImp>();

            services.AddTransient<PTCGWebApplicationContext>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
