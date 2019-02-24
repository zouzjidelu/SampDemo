using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OauthSample.AuthService
{
    /// <summary>
    /// 客户端提供者
    /// </summary>
    public class ClientProvider
    {
        public static List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="zerodo",
                    ClientName="零度A公司",
                    ClientSecrets=new List<Secret>//给客户端密钥颁发的密钥
                    {
                        new Secret{ Value="qwert".Sha256()},
                    },
                    AccessTokenType=AccessTokenType.Reference,//访问token类型，引用类型
                    AllowedScopes=new List<string>{ "webapi1"},//允许客户端访问的范围
                    Flow=Flows.ClientCredentials,
                    Claims=new List<Claim>//声明，分组
                    {
                        new Claim("role","role"),
                        //new Claim("role2","role2")
                    },
                    Enabled=true,
                },
                new Client
                {
                    ClientId="zerodo2",
                    ClientName="零度B公司",
                    ClientSecrets=new List<Secret>//给客户端密钥颁发的密钥
                    {
                        new Secret{ Value="asdfg".Sha256()},
                    },
                    AccessTokenType=AccessTokenType.Reference,//访问token类型，引用类型
                    AllowedScopes=new List<string>{ "webapi2"},//允许客户端访问的范围
                    Flow=Flows.ClientCredentials,
                    Claims=new List<Claim>//声明，分组
                    {
                        new Claim("role2","role2")
                    },
                    Enabled=true,
                },
                new Client
                {
                    ClientId="zerodo3",
                    ClientName="千图网",
                    
                    //AllowedScopes=new List<string>{ "webapi2"},//允许客户端访问的范围
                    AllowAccessToAllScopes=true,
                    Flow=Flows.Implicit,
                   RedirectUris=new List<string>//指定允许URI将令牌或授权代码返回到 
                   {
                       "http://localhost:7000/"
                   },
                   PostLogoutRedirectUris=new List<string>//指定允许在注销后重定向到的URI 
                   {
                       "http://localhost:7000/"
                   }
                }
            };
        }
    }
}
