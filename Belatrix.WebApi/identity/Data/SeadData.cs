using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.WebApi.identity.Data
{
    public class SeadData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbcontext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            context.Database.EnsureCreated();

            if (!context.UserClaims.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "test@bela.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "cnoel"
                };
                userManager.CreateAsync(user, "Welcome123!");
            }
        }
    }
}
