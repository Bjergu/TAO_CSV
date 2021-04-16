using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TAO_CSV_v06.Startup))]
namespace TAO_CSV_v06
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
