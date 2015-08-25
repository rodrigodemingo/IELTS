using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IELTS_Portal.Startup))]
namespace IELTS_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
