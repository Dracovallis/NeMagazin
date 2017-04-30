using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NeMagazin.Web.Startup))]
namespace NeMagazin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
