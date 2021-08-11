using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwhH5.Areas.Identity.Codes
{
    public class UserRoleHandler
    {
        public async Task CreateRole(string user, string role, IServiceProvider _serviceProvider)
        {
            var RoleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

           await RoleManager.CreateAsync(new IdentityRole(role));

            IdentityUser identityUser = await UserManager.FindByEmailAsync(user);
            await UserManager.AddToRoleAsync(identityUser, role);
        }
    }
}
