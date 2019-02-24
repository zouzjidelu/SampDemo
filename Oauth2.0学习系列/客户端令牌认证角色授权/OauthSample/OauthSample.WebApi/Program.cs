using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OauthSample.WebApi
{
    /// <summary>
    /// 资源服务器，开发的webapi资源供客户端【第三方】使用
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:6000"))
            {
                Console.WriteLine("WebApi Server Start");
                Console.ReadKey();
            }
        }
    }
}
