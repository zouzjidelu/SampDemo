using Microsoft.Owin.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OauthSample.AuthService
{
    /// <summary>
    /// 认证服务器
    /// 
    /// oauth作为网络开放 授权协议的标准，各语言都有各自的实现框架，.net是通过identityserver
    /// 实现的，故，需要安装identityserver3的框架，还有id4，这个是在core中使用的，虽然也能在asp.net
    /// 中使用，但是不支持webapi2！
    /// 1.安装identityserver Install-Package IdentityServer3
    /// 2.安装完成之后，认证服务器需要提供 客户端【Client】，以及范围【Scops】，在客户端请求认证服务器获取token的时候用的
    /// 2.1.客户端拿到token会去请求webapi资源，那么在webapi资源服务器那边会做认证token是不是认证服务器颁发的[此步骤不是在这里做的]
    /// 3.认证服务器提供了客户端和范围后，需要将授权服务器进行自宿主到owin上，故，和webapi【资源服务器】
    ///    自宿主的步骤是一样的  安装 Install-Package Microsoft.Owin.SelfHost
    /// 3.1 创建startup启动类,配置identityseroptions
    /// 3.2在main方法中启动认证授权服务器，启
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().
WriteTo.LiterateConsole(outputTemplate: "{Timestamp:HH:mm:ss}-[{Level}]-{Message} {Exception} {NewLine}").CreateLogger();

            using (WebApp.Start<Startup>("http://localhost:5000"))
            {
                Console.WriteLine("Auth Server Start");
                Console.ReadKey();
            }
        }
    }
}
