using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KienLongC.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KienLongC.Data;
using Microsoft.EntityFrameworkCore;
using BotDetect;
using BotDetect.Web;
using Microsoft.AspNetCore.Http;

namespace KienLongC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Bot
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddRazorPages(option => option.Conventions.AuthorizeAreaPage("Identity","/Home/Form","User"));
            services.AddControllersWithViews();
            services.AddDbContext<tblKienLongF>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("tblKienLongF")));
            // Add Session services. Bot
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.IsEssential = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,tblKienLongF db )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // configure Session middleware
            app.UseSession();

            // configure your application pipeline to use Captcha middleware
            // Important! UseCaptcha(...) must be called after the UseSession() call
            app.UseCaptcha(Configuration);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Home}/{id?}");

            });

        }
    }
}
