using System;
using AlquilerDeBicicletas.Areas.Identity.Data;
using AlquilerDeBicicletas.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AlquilerDeBicicletas.Areas.Identity.IdentityHostingStartup))]
namespace AlquilerDeBicicletas.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AlquilerDeBicicletasContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AlquilerDeBicisDBConnection")));

                services.AddDefaultIdentity<AlquilerDeBicicletasUsers>()
                    .AddEntityFrameworkStores<AlquilerDeBicicletasContext>();
            });
        }
    }
}