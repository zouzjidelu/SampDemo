using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OauthSample.AuthService
{
    /// <summary>
    /// 用户提供者，用户是腾讯的用户，需要在千图网客户端请求登陆，登陆的方式是通过请求腾讯的认证授权登陆到千图网
    /// 中，千图网，需要记录该用户的qq，在自己的服务器上，进行匹配该用户是否是自己服务器上的，以及该用户有哪些角色，访问
    /// 哪些资源
    /// </summary>
    public class UserProvider
    {
        public static List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject="1",//用户的id
                    Username="zhangsan",
                    Password="zhangsan",
                    Claims=new []
                    {//用户的声明，也就是用户在腾讯上的用户携带的信息，可以是任意的信息，是为了区分系统的每个用户，
                        new Claim("role","AboutGroup"),
                    }
                },
                new InMemoryUser
                {
                    Subject = "2",
                    Username = "lisi",
                    Password = "lisi",
                    Claims = new[]
                    {
                       new Claim("role","ContactGroup"),
                    }
                },
                new InMemoryUser
                {
                    Subject = "3",
                    Username = "wangwu",
                    Password = "wangwu",
                    Claims = new[]
                    {
                      new Claim("role","A"),//如果我设置了A、B，【关于】、【联系】这两个action都不能访问
                      new Claim("role","B"),
                    }
                }
            };
        }
    }
}
