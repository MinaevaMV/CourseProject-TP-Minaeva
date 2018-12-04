using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppV2.Startup))]
namespace WebAppV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
