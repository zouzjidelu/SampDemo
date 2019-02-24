using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.InMemory;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OauthSample.AuthService
{
    /// <summary>
    /// 认证授权服务器启动配置类
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var options = new IdentityServerOptions
            {
                Factory = new IdentityServerServiceFactory()
                .UseInMemoryUsers(UserProvider.GetUsers())//内存用户
                .UseInMemoryScopes(ScopeProvider.GetScopes())
                .UseInMemoryClients(ClientProvider.GetClients()),
                RequireSsl = false,//是否使用https
                AuthenticationOptions = new AuthenticationOptions
                {
                    EnablePostSignOutAutoRedirect = true//自动跳转到登出页面
                },
                //生成一个证书 密码123456
                SigningCertificate = new X509Certificate2($@"{AppDomain.CurrentDomain.BaseDirectory}\Certificate\idsrv3test.pfx", "idsrv3test"),
               
            };

            appBuilder.UseIdentityServer(options);

        }
    }
}
