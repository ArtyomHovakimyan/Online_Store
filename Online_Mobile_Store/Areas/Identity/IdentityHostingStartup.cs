using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Online_Mobile_Store.Models;

[assembly: HostingStartup(typeof(Online_Mobile_Store.Areas.Identity.IdentityHostingStartup))]
namespace Online_Mobile_Store.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Online_Mobile_StoreContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Online_Mobile_StoreContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<Online_Mobile_StoreContext>();
            });
        }
    }
}