using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace OauthSample.WebApi
{
    /// <summary>
    /// 资源授权管理器
    /// 资源管理器的检查功能写完之后，需要配置到管道当中，才可进行授权验证
    /// </summary>
    public class AuthorizationManager : ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            //首先获得所有的权限
            var permissions = PermissionProvider.GetPromissions();
            //在权限集合中检查，当前的客户端请求的资源中是否在权限集合中有，
            //并且客户端携带的角色是否包含一个与权限集合相匹配的，如果有，则通过

            //context.Principal.HasClaim("client_role2", p.RoleName)这句话判断的是当前请求的客户端携带的角色名称和权限集合中的名称是否有匹配的
            //client_role2客户端角色名称这里是写死的，应该进行灵活匹配
            //if (permissions.Any(p => context.Resource.Any(r => r.Value == p.ResourceName && context.Principal.HasClaim("client_role2", p.RoleName))))
            //{
            //    return Ok();
            //}

            if (permissions.Any(p => context.Resource.Any(r => r.Value == p.ResourceName
            && context.Principal.Claims.Any(c => c.Value == p.RoleName))))
            {
                return Ok();
            }

            //同上，这里检测的是action
            if (permissions.Any(p => context.Action.Any(a => a.Value == p.ActionName
            && context.Principal.Claims.Any(c => c.Value == p.RoleName))))
            //&& context.Principal.HasClaim("client_role", p.RoleName))))
            {
                return Ok();
            }
            return Nok();
        }
    }
}
