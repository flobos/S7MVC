using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S7MVC.Startup))]
namespace S7MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
