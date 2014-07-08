using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eid.MVC.Startup))]
namespace Eid.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
