using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<ApplicationUser> userManager,
           RoleManager<ApplicationRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            //var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            //var users = JsonSerializer.Deserialize<List<ApplicationUser>>(userData);
            //if (users == null) return;

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
                //new ApplicationRole{Name = "Moderator"},
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
                //PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                //passwordHasher.HashPassword(user, "Admin*123");
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

            //var admin = new ApplicationUser
            //{
            //    UserName = "admin"
            //};

            //await userManager.CreateAsync(admin, "Pa$$w0rd");
            //await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
        }
    }
}
