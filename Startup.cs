using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pasteleria_dd.Startup))]
namespace pasteleria_dd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
