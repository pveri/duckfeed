using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ducks.Application.Startup))]
namespace Ducks.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
