using Microsoft.AspNet.Identity.EntityFramework;
using OnlineSmartPhoneShop_DbContext.Migrations;
using OnlineSmartPhoneShop_Entities.Models;
using OnlineSmartphonesShop.Models;
using System.Data.Entity;

namespace OnlineSmartPhoneShop_DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public virtual IDbSet<Smartphone> Smartphones { get; set; }

        public ApplicationDbContext()
            //: base("OnlineShopConnection", throwIfV1Schema: false)
            : base("OnlineShopConnection-Prod", throwIfV1Schema: false)

        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
           // this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}
