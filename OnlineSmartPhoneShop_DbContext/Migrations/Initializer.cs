using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineSmartPhoneShop_CommonFiles;
using OnlineSmartphonesShop.Models;
using System;
using System.Linq;

namespace OnlineSmartPhoneShop_DbContext.Migrations
{
    internal class Initializer
    {
        internal static void SeedRoles(ApplicationDbContext context)
        {
            string[] roles =
            {
                "Administrator",
                "Guest"
                
            };

            foreach (var role in roles)
            {
                var roleStore = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.Create(new IdentityRole(role));
                }
            }
        }

        internal static void SeedUser(ApplicationDbContext context)
        {
            string userName = "Alex";
            string role = "Owner";
            var userRole = new IdentityRole { Id = new CustomId().ToString(), Name = role };
            context.Roles.Add(userRole);

            var hasher = new PasswordHasher();

            var user = new User
            {
                UserName = userName,
                PasswordHash = hasher.HashPassword("1"),
                Email = "sashe944@abv.bg",
                EmailConfirmed = true,
                SecurityStamp = new CustomId().ToString()
            };

            user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });
            context.Users.Add(user);

        }
    }
}