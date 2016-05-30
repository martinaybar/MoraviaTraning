using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoraviaTraning.Web.Startup))]
namespace MoraviaTraning.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
