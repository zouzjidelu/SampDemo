using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OauthSample.WebApi
{
    /// <summary>
    /// 权限提供者，客户端访问资源，需要对客户端指定角色，以及角色能够访问 对应的权限【资源】
    /// </summary>
    public class PermissionProvider
    {
        private readonly static List<Permission> permissions = new List<Permission>();
        static PermissionProvider()
        {
            permissions.Add(new Permission { RoleName = "role", ActionName = "GetBooks" });
            permissions.Add(new Permission { RoleName = "role", ActionName = "GetBook" });
            permissions.Add(new Permission { RoleName = "role2", ResourceName = "Book" });
        }

        public static List<Permission> GetPromissions()
        {
            return permissions;
        }

    }

    /// <summary>
    /// 权限实体类
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        public string ActionName { get; set; }
    }
}
