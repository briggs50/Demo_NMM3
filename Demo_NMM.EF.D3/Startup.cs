using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo_NMM.EF.D2.Startup))]
namespace Demo_NMM.EF.D2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
