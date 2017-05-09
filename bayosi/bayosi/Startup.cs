using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bayosi.Startup))]
namespace bayosi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
