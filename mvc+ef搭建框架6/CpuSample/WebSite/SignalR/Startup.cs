using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebSite.SignalR.Startup))]
namespace WebSite.SignalR
{
    /// <summary>
    /// SignalR启动类---在应用程序启动前执行
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}