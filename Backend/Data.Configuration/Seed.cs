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

            // check if contents in the user table, if not continue

            if (await userManager.Users.AnyAsync()) return;
            
            // to be changed later, seed the categories if no users exists
            CategoryConfigration categories = new();


            // create roles
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


            // create roles
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


            // save roles to db
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }


            // save users to db and append roles to them
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
