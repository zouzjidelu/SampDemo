using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OauthSample.AuthService
{
    /// <summary>
    /// 资源提供者【这里的意思是客户端访问的大的范围，这里是webapi，不如还有图片，视频等等，这里指的是webapi】
    /// </summary>
    public class ScopeProvider
    {
        public static List<Scope> GetScopes()
        {
            var scopes= new List<Scope> {
                new Scope{ Name="webapi1",Type=ScopeType.Resource,DisplayName="演示webapi1"},
                new Scope{ Name="roles",Type=ScopeType.Identity,Claims=new List<ScopeClaim>{ new ScopeClaim("role") } }
            };

            scopes.AddRange(StandardScopes.All);

            return scopes;
        }
    }
}
