using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OauthSample.Web
{
    public class PermissionProvider
    {
        public IEnumerable<Permission> GetAllPermissions()
        {
            List<Permission> permissions = new List<Permission>();

            permissions.Add(new Permission { RoleName = "AboutGroup", ActionName = "About" });
            permissions.Add(new Permission { RoleName = "ContactGroup", ActionName = "Contact" });
            permissions.Add(new Permission { RoleName = "AllGroup", ResourceName = "HomeManager" });

            return permissions;
        }
    }

    public class Permission
    {
        public string RoleName { get; set; }

        public string ResourceName { get; set; }

        public string ActionName { get; set; }
    }
}