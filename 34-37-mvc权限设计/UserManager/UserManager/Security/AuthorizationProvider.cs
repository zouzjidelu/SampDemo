using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManager.Entitys;

namespace UserManager.Security
{
    /// <summary>
    /// 授权提供者
    /// </summary>
    public class AuthorizationProvider : IAuthorizationProvider
    {
        public bool Authorize(string permissionName, User user)
        {
            return user.Roles.Where(role => role.Active).Any(role => Authorize(permissionName, role));
        }

        public bool Authorize(string permissionName)
        {
            return this.Authorize(permissionName, WorkContext.CurrentUser);
        }

        protected virtual bool Authorize(string permissionName, Role role)
        {
            return role.Permissions.Any(p => p.Name.Equals(permissionName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}