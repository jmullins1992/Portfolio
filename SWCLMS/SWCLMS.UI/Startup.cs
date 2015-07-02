using Microsoft.Owin;
using Owin;
using SWCLMS.UI;

[assembly: OwinStartup(typeof(Startup))]
namespace SWCLMS.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
