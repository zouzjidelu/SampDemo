using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace IdentityServerSample
{
    /// <summary>
    /// 客户端类[认证服务器]
    /// </summary>
    public static class Clients
    {
        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetClients()
        {
            List<Client> clients = new List<Client>
            {
                new Client
                {
                    ClientId="lingdu",//客户端id
                    ClientName="零度",//客户端名称
                    AccessTokenType=AccessTokenType.Reference,//访问token类型
                    Enabled=true,//是否允许访问客户端
                    Flow=Flows.ClientCredentials,//认证模式
                    ClientSecrets=new List<Secret>
                    {
                        new Secret("41223EDC","第一个客户端秘钥")
                    },
                    AllowedScopes=new List<string>{ "api1" } 
                    
                }
            };

            return clients;
        }
    }
}
