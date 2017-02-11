using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AyudarXAyudar.Startup))]
namespace AyudarXAyudar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
