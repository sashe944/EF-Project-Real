using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineSmartphonesShop.Models
{

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("OnlineShopConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}