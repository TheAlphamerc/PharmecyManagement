using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PharmAssistent.Startup))]
namespace PharmAssistent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
