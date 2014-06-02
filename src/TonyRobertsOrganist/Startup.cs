using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TonyRobertsOrganist.Startup))]
namespace TonyRobertsOrganist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
