using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;

namespace WebApiCore.Data
{
    public class SeedDatabase
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TodoContext>();

            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                AppUser user = new AppUser
                {
                    Email = "adri@mail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Adri"
                };

                IdentityResult result = await userManager.CreateAsync(user, "Geralt12345!@");

            }
        }
    }
}
