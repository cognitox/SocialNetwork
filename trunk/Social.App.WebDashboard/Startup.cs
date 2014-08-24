using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Social.App.WebDashboard.Startup))]
namespace Social.App.WebDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
