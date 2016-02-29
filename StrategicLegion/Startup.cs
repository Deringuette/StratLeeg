using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StrategicLegion.Startup))]
namespace StrategicLegion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
