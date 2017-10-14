using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFBANXE.Startup))]
namespace EFBANXE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
