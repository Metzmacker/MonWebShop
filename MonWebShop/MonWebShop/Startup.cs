using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonWebShop.Startup))]
namespace MonWebShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
