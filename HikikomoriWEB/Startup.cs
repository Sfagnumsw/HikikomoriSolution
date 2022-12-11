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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HikikomoriWEB
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services) //���������� ������������ � ������� �������� � MVC
        {
            Configuration.Bind("Project", new Config()); //����������� ������������ �� appsettings.json � ���������� � �������������� �������

            //services.AddMvc(options => options.EnableEndpointRouting = false); //������ ������ ������������� ����� configure(��������� ��������)

            services.AddScoped<IContentServices<RateContentViewModel>, RateContentService>(); //����������� BL
            services.AddScoped<IBaseContentRepository<RateContent>, RateContentRepository>();
            services.AddScoped<IContentServices<RememberContentViewModel>, RememberContentService>();
            services.AddScoped<IBaseContentRepository<RememberContent>, RememberContentRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddDbContext<HikDbContext>(i => i.UseSqlServer(Config.ConnectionString, b => b.MigrationsAssembly("HikikomoriWEB"))); //����������� ��������� ��
            services.AddIdentity<IdentityUser, IdentityRole>(opts => { 
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireLowercase = true;
            }).AddEntityFrameworkStores<HikDbContext>(); //����������� �������������
            services.ConfigureApplicationCookie(opts => { opts.LoginPath = "/Account/Login"; opts.Cookie.HttpOnly = false; opts.Cookie.Name = "HikSfag"; });
            services.AddAuthorization();
            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider(); //����������� ��������� MVC � ������������� ������ asp.net core 3(����� �������) , � ��� �� ������� ��� ������������ � �������������
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //����� ����� ������� ����������� ����������� middeleware (��� ������� ��������� �������(��� ���������� ����������� ��������))
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //���� � ��������� ���������� �� ������� ��������� ���� �� �������
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseStaticFiles(); //��������� ��������� ������ (css,js...)
            app.UseRouting(); //������� ������������� (���� ���������� AddMvc, �� ������������� ��������� � ��������� ������������ � �������)
            app.UseAuthentication(); // ��������������
            app.UseAuthorization(); // �����������
            app.UseCookiePolicy(); //�������� ����� �� �������� �����
            app.UseStatusCodePages(); //��������� ������ http (404...)
            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); }); //������������� ��� useRouting(���� � ������ �� �������� ����������, �� ���������� �� ��������� ���������� ��� ������� �������� � �����)
            //app.UseMvcWithDefaultRoute(); //������ ������ �������������
        }
    }
}
