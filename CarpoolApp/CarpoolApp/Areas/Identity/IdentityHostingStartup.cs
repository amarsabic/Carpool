using System;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CarpoolApp.Areas.Identity.IdentityHostingStartup))]
namespace CarpoolApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CarpoolAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CarpoolAppContextConnection")));

                services.AddDefaultIdentity<Korisnik>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CarpoolAppContext>();
            });
        }
    }
}