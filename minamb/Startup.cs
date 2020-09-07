using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(minamb.Startup))]
namespace minamb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
