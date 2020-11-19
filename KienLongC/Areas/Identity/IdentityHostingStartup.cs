using System;
using KienLongC.Areas.Identity.Data;
using KienLongC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(KienLongC.Areas.Identity.IdentityHostingStartup))]
namespace KienLongC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<KienLongCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("tblKienLongF")));

                services.AddDefaultIdentity<KienLongCUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<KienLongCContext>();
            });
        }
    }
}