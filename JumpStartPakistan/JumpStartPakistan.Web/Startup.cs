using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JumpStartPakistan.Web.Startup))]
namespace JumpStartPakistan.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
