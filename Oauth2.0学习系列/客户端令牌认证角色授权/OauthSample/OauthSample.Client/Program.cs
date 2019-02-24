using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OauthSample.Client
{
    /// <summary>
    /// 客户端【第三方应用程序】
    /// 假如 这里是千图网，去访问腾讯服务器，获取token，拿到token去访问腾讯开发的webapi资源，
    /// webapi资源服务器 需要认证 该客户端是否是通过认证服务器颁发的token，通过则放行，可访问
    /// 但是具体访问哪些资源，这里需要给客户端分配一个角色，该角色可以访问哪些资源。
    /// 既然说到了客户端访问资源，需要webapi进行认证客户端。故，要在webapi去做token认证
    /// 
    /// 客户端请求授权服务器上的token，可以通过原始的httpclient的方式进行访问，那么微软提供了一个组件，
    /// 方便的去请求资源，以及获取授权服务器上颁发的token
    /// 故，安装组件
    /// 1.Install-Package IdentityModel -version 3.0.0
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //在授权服务器上获取token
            TokenClient tokenClient = new TokenClient("http://localhost:5000/connect/token", "zerodo", "qwert");
            var result = tokenClient.RequestClientCredentialsAsync("webapi1").Result;//webapi1：客户端请求的范围，在这个范围上，返回一个token
            if (result.IsError)
            {
                Console.WriteLine(result.Error);
            }
            else
            {
                //result.AccessToken
                //拿到认证授权服务器上的token后去访问资源
                HttpClient httpClient = new HttpClient();
                httpClient.SetBearerToken(result.AccessToken);//请求头设置token
                //请求资源
                //var data = httpClient.GetStringAsync("http://localhost:6000/api/Book/GetBook?bookId=1").Result;
                var data = httpClient.GetStringAsync("http://localhost:6000/api/Book").Result;
                Console.WriteLine(data);
            }
            Console.ReadKey();
        }
    }
}
