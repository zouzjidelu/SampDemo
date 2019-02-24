using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using IdentityModel;
using IdentityServer3.AccessTokenValidation;

namespace OauthSample.WebApi
{
    /// <summary>
    /// webapi启动配置类，类似于web中的gloab文件
    /// 1.首先将webapi进行自宿主，需要用到owin自宿主服务器，
    ///   不会的，百度搜索如何自宿主  Use OWIN to Self-Host ASP.NET Web API
    ///   ,根据官网的提示，进行配置即可
    /// 2.配置完成，创建一个webapi控制器，写入几个方法，进行测试，是否自宿主成功
    /// 3.webapi资源服务器需要配置token认证，保证客户端访问的token是认证服务器颁发的
    ///   那么验证token，identityserver所属的公司也开发一套验证的组件，需要安装
    ///   1.Install-Package IdentityServer3.AccessTokenValidation -Version 2.15.1
    /// 4.客户端访问webapi资源，token认证成功后，需要针对客户端进行验证授权访问资源的范围，拥有访问哪些api的权限
    ///   1.Install-Package Thinktecture.IdentityModel.Owin.ResourceAuthorization.WebApi -Version 3.0.0
    /// 5.验证授权范围，需要写一个授权管理器AuthorizationManager，检查有没有访问api资源的权限
    /// 6.资源管理器的检查功能写完之后，需要配置到管道当中，才可进行授权验证
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            { //1.客户端认证检查
              //验证客户端传递过来的token是否合法，是否是授权服务器颁发的
                appBuilder.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = "http://localhost:5000",//获取到的token到哪儿验证?认证授权服务器
                    ValidationMode = ValidationMode.ValidationEndpoint,//验证模式，验证终结点，也就是认证服务器上的地图
                    RequiredScopes = new List<string> { "webapi1" },//认证的资源范围
                });

            }

            {//2.客户端授权检查
                appBuilder.UseResourceAuthorization(new AuthorizationManager());
            }

            HttpConfiguration configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            appBuilder.UseWebApi(configuration);
        }
    }
}
