using System;
using JwhH5.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(JwhH5.Areas.Identity.IdentityHostingStartup))]
namespace JwhH5.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<JwhH5Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("JwhH5ContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<JwhH5Context>();

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireAuthenticatedUser", policy =>
                    {
                        policy.RequireAuthenticatedUser();
                    });

                    options.AddPolicy("RequireAdminUser", policy =>
                    {
                        policy.RequireRole("Admin");
                    });

                });
            });
        }
    }
}