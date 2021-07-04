using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ToplantiTakip.WebUI.Startup))]

namespace ToplantiTakip.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
