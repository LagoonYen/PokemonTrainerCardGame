using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PokemonTrainerCardGame.Data;
using PokemonTrainerCardGame.Service;
using PokemonTrainerCardGame.Repository;
using PokemonTrainerCardGame.Common;
using PokemonTrainerCardGame.Models;
using Microsoft.OpenApi.Models;
using System.IO;
using System;
using System.Reflection;

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
            services.AddControllers();  //controller相關
            services.AddRazorPages();  //razor page相關 

            //db相關
            services.AddDbContext<PokemonTrainerCardGameContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PokemonTrainerCardGameContext")));

            //services.AddDbContext<PokemonTrainerCardGameContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("PTCGDB")));

            //swagger相關
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "PTCG API", 
                    Version = "v1",
                    Description = "寶可夢卡牌CRUD",
                    //範例
                    //TermsOfService = new Uri("https://igouist.github.io/"),
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Igouist",
                    //    Email = string.Empty,
                    //    Url = new Uri("https://igouist.github.io/about/"),
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = "TEST",
                    //    Url = new Uri("https://igouist.github.io/about/"),
                    //}
                });

                // 讀取 XML 檔案產生 API 說明
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //DI註冊CardService及Repository的實作
            //services.AddScoped<CardService, CardServiceImp>();
            services.AddScoped<CardService, CardServiceImpEF>();
            //services.AddScoped<CardRepository, CardRepositoryImp>();
            services.AddScoped<CardRepository, CardRepositoryImpEF>();

            services.AddScoped<AppSetting, AppSettingImp>();

            services.AddTransient<PTCGWebApplicationContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Swagger相關
                app.UseSwagger();
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "PTCG Api");
                    x.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();  //Razor Page相關

            app.UseAuthorization();  //Razor Page相關

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();  //Razor Page相關
                endpoints.MapControllers();  //API Controller相關
            });
        }
    }
}
