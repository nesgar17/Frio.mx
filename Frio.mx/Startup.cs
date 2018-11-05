using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Frio.mx.Startup))]
namespace Frio.mx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
