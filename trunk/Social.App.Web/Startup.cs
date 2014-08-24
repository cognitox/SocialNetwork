using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Social.App.Web.Startup))]
namespace Social.App.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
