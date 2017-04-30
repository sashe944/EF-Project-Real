using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineSmartphonesShop.Startup))]
namespace OnlineSmartphonesShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
