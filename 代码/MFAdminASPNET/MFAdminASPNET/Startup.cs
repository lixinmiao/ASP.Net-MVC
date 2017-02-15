using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MFAdminASPNET.Startup))]
namespace MFAdminASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
