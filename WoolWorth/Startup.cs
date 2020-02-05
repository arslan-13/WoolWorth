using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WoolWorth.Startup))]
namespace WoolWorth
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
