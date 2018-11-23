using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Goof_.Startup))]
namespace Goof_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
