using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LicenseManagerMvc.Startup))]
namespace LicenseManagerMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
