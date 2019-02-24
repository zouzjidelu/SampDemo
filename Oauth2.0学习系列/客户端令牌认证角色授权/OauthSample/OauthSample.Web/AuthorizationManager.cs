using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace OauthSample.Web
{
    public class AuthorizationManager : ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            PermissionProvider permissionProvider = new PermissionProvider();

            IEnumerable<Permission> permissions = permissionProvider.GetAllPermissions();

            if (permissions.Any(p => context.Resource.Any(r => r.Value == p.ResourceName && context.Principal.HasClaim("role", p.RoleName))))
            {
                return Ok();
            }

            if (permissions.Any(p => context.Action.Any(a => a.Value == p.ActionName && context.Principal.HasClaim("role", p.RoleName))))
            {
                return Ok();
            }

            return Nok();
        }
    }
}