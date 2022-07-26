using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Models;


namespace Data.Configuration
{
    public class UserConfiguration
    {

        public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            // create roles
            var user = new ApplicationUser
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                FName = "Admin",
                LName = "Admin"
            };

            // save users to db and append roles to them
                await userManager.CreateAsync(user, "Admin123+");
                await userManager.AddToRoleAsync(user, "Admin");

        }
    }
}
