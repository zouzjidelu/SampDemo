using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniProfilerSample.Startup))]
namespace MiniProfilerSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
