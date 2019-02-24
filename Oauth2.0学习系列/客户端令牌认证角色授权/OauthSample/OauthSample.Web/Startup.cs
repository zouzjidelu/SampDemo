using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using Thinktecture.IdentityModel.Client;

[assembly: OwinStartup(typeof(OauthSample.Web.Startup))]

namespace OauthSample.Web
{
    /// <summary>
    /// 将iis的请求通过适配器的方式传递给owin自宿主服务器，因为idserver3是通过owin的宿主、运行的
    /// </summary>
    public class Startup
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    app.UseResourceAuthorization(new AuthorizationManager());

        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = "Cookies"
        //    });

        //    app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
        //    {
        //        Authority = "http://localhost:5000",
        //        ClientId = "zerodo3",
        //        RedirectUri = "http://localhost:7000/",
        //        ResponseType = "id_token token",
        //        SignInAsAuthenticationType = "Cookies",
        //        Scope = "openid profile roles webapi1",
        //        UseTokenLifetime = false,

        //        Notifications = new OpenIdConnectAuthenticationNotifications()
        //        {
        //            SecurityTokenValidated = async n =>
        //            {

        //                var cookieUser = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType, "role", "role");

        //                var userInfoUri = new Uri(n.Options.Authority + "/connect/userinfo");
        //                var userInfoClient = new UserInfoClient(userInfoUri, n.ProtocolMessage.AccessToken);

        //                var userInfo = await userInfoClient.GetAsync();

        //                userInfo.Claims.ToList().ForEach(ui => cookieUser.AddClaim(new Claim(ui.Item1, ui.Item2)));

        //                cookieUser.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
        //                cookieUser.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));

        //                n.AuthenticationTicket = new AuthenticationTicket(cookieUser, n.AuthenticationTicket.Properties);
        //            },

        //            RedirectToIdentityProvider = n =>
        //            {

        //                if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.Logout)
        //                {
        //                    var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

        //                    if (idTokenHint != null)
        //                    {
        //                        n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
        //                    }
        //                }

        //                return Task.FromResult(0);
        //            }
        //        }
        //    });
        //}

        public void Configuration(IAppBuilder app)
        {
            //app.UseResourceAuthorization(new AuthorizationManager());

            //cookie认证
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "Cookies",
            });

            //openidconnect 认证
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "http://localhost:5000",//认证授权服务器地址
                ClientId = "zerodo3",//认证的客户端？这里需要是客户端提供者中所填写的客户端id
                RedirectUri = "http://localhost:7000/",////认证完成后跳转到第三方的url地址，开发过微信就知道，微信必须提供认证后返回的url
                ResponseType = "id_token token",
                SignInAsAuthenticationType = "Cookies",//认证类型 cookies，与上面cookie认证配置的认证type要一样
                Scope = "openid profile roles webapi1",//资源范围，
                UseTokenLifetime = false,//不使用token的生命周期
                                         //RequireHttpsMetadata=false,
                Notifications = new OpenIdConnectAuthenticationNotifications//认证完成后的通知配置
                {
                    //安全令牌已验证 
                    SecurityTokenValidated = async n =>
                     {
                         //1.获取用户的cookie
                         var cookieUser = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType, "role", "role");

                         //2.获取用户信息
                         var userInfoUri = new Uri(n.Options.Authority + "/connect/userinfo");
                         var userInfoClient = new UserInfoClient(userInfoUri, n.ProtocolMessage.AccessToken);
                         var userInfo = await userInfoClient.GetAsync();

                         //3.将用户的声明，也就是携带的信息，添加到当前用户的cookie中的声明中
                         userInfo.Claims.ToList().ForEach(ui =>
                      {
                          cookieUser.AddClaim(new Claim(ui.Item2, ui.Item2));
                      });
                         cookieUser.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                         cookieUser.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));

                         //4.身份验证票据
                         n.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(cookieUser, n.AuthenticationTicket.Properties);
                     },
                    //调用以操作指向标识提供程序的重定向以进行登录、注销或挑战。
                    RedirectToIdentityProvider = n =>
                    {
                        //如果请求类型是退出
                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.Logout)
                        {
                            //则找到当前用户的token，并注销
                            var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");
                            if (idTokenHint != null)
                            {
                                n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                            }
                        }
                        return Task.FromResult(0);
                    }
                },
            });
        }
    }
}
