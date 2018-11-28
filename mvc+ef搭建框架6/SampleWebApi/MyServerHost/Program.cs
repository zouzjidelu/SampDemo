using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace MyServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取当前工作目录下的plugins文件夹下的所有文件
            string[] files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "plugins"));
            foreach (var file in files)
            {
                Assembly.LoadFile(file);
            }
            var config = new HttpSelfHostConfiguration("http://127.0.0.1:5678");
            config.Routes.MapHttpRoute(   
                name: "DefaultApi",
                routeTemplate: "api2/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();//因为是异步的，所以要等待
            Console.WriteLine("WebApi自宿主服务已启动！");
            Console.ReadKey();
        }
    }
}
