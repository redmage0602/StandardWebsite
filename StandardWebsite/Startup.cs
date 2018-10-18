using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StandardWebsite.Startup))]
namespace StandardWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
