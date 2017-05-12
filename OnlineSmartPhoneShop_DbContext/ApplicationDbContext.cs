using Microsoft.AspNet.Identity.EntityFramework;
using OnlineSmartPhoneShop_DbContext.Migrations;
using OnlineSmartphonesShop.Models;
using System.Data.Entity;

namespace OnlineSmartPhoneShop_DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("OnlineShopConnection", throwIfV1Schema: false)
            //: base("OnlineShopConnection-Prod", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<OnlineSmartPhoneShop_Entities.Models.Smartphone> Smartphones { get; set; }
    }
}
