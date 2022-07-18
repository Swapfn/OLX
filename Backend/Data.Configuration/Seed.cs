using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Models;


namespace Data.Configuration
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<ApplicationUser> userManager,
           RoleManager<ApplicationRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new ApplicationRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "Admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FName = "Admin",
                    LName = "Admin"
                },
                new ApplicationUser
                {
                    UserName = "User",
                    NormalizedUserName = "USER",
                    Email = "User@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FName = "User",
                    LName = "User"
                }
            };


            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                    user.UserName = user.UserName.ToLower();
                    await userManager.CreateAsync(user, "Admin123+");
                if (user.UserName.ToLower() == "admin")
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }

        }
    }
}
