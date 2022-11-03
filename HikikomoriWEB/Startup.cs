using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HikikomoriWEB.DAL.Context;
using HikikomoriWEB.DAL.Interfaces;
using HikikomoriWEB.DAL.EFRepositories;
using HikikomoriWEB.Services.Interfaces;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Services.RepositoryServices;
using HikikomoriWEB.Domain.ViewModels;

namespace HikikomoriWEB
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services) //функционал подключается с помощью сервисов в MVC
        {
            Configuration.Bind("Project", new Config()); //подключение конфигурации из appsettings.json и связывание с соответсвующим классом

            //services.AddMvc(options => options.EnableEndpointRouting = false); //другой способ маршрутизации через configure(отключаем эндпоинт)

            services.AddScoped<IBaseContentServices<RateContentViewModel>, RateContentService>(); //подключение BL
            services.AddScoped<IBaseContentRepository<RateContent>, RateContentRepository>();
            services.AddScoped<IBaseContentServices<RememberContentViewModel>, RememberContentService>();
            services.AddScoped<IBaseContentRepository<RememberContent>, RememberContentRepository>();
            services.AddDbContext<HikDbContext>(i => i.UseSqlServer(Config.ConnectionString, b => b.MigrationsAssembly("HikikomoriWEB"))); //подключение контекста БД
            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider(); //подключение поддержки MVC и совместимость версий asp.net core 3 , а так же сервисы для контроллеров и предствалений
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //очень важен порядок подключения компонентов middeleware
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //если в окружении разработки то выводит подробную инфу об ошибках
            }
            app.UseStaticFiles(); //поддержка статичных файлов (css,js...)
            app.UseRouting(); //система маршрутизации (если используем AddMvc, то устанавливаем дефолРоут и отключаем эндпоинтРоут в сервисе)
            app.UseStatusCodePages(); //обработка ошибок http (404...)
            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); }); //маршрутизация под useRouting(если в адресе не прописан контроллер, то используем по умолчанию контроллер для главной страницы и метод)
            //app.UseMvcWithDefaultRoute(); //другой способ маршрутизации
        }
    }
}
