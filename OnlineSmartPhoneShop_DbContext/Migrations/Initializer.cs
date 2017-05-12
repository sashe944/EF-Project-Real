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
                "Administrator"
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

        internal static void SeedUsers(ApplicationDbContext context)
        {
            string userNameOwner = "Alex";
            string roleOwner = "Owner";
            var userRoleOwner = new IdentityRole { Id = new CustomId().ToString(), Name = roleOwner };
            context.Roles.Add(userRoleOwner);

            var ownersPassword = new PasswordHasher();

            var owner = new User
            {
                UserName = userNameOwner,
                PasswordHash = ownersPassword.HashPassword("1"),
                Email = "sashe944@abv.bg",
                EmailConfirmed = true,
                SecurityStamp = new CustomId().ToString()
            };

            owner.Roles.Add(new IdentityUserRole { RoleId = userRoleOwner.Id, UserId = owner.Id });
            context.Users.Add(owner);

            string userNameGuest = "Belgin";
            string roleGuest = "Guest";
            var userRoleGuest = new IdentityRole { Id = new CustomId().ToString(), Name = roleGuest };
            context.Roles.Add(userRoleGuest);

            var guestsPassword = new PasswordHasher();

            var guest = new User
            {
                UserName = userNameGuest,
                PasswordHash = guestsPassword.HashPassword("1"),
                Email = "belgin94@abv.bg",
                EmailConfirmed = true,
                SecurityStamp = new CustomId().ToString()
            };

            guest.Roles.Add(new IdentityUserRole { RoleId = userRoleGuest.Id, UserId = guest.Id });
            context.Users.Add(guest);
        }
    }
}