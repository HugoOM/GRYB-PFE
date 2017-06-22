using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GRYB_Admin.Startup))]
namespace GRYB_Admin
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
