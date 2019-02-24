using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace IdentityServerSample
{
    /// <summary>
    /// 权限【资源服务器】
    /// </summary>
    public static class Scopes
    {
        /// <summary>
        /// 获得资源权限，可以从数据库获取
        /// </summary>
        /// <returns></returns>
        public static List<Scope> GetScopes()
        {
            List<Scope> scopes = new List<Scope>
            {
                new Scope{Name="api1",DisplayName="这是api1" },
                new Scope{Name="api2",DisplayName="这是api2" }
            };

            return scopes;
        }
    }
}
