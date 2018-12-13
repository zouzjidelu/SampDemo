using System.Collections.Generic;
using UserManager.Entitys;

namespace UserManager.Security
{
    /// <summary>
    /// 角色权限提供这类
    /// </summary>
    public class PermissionProvider : IPermissionProvider
    {
        public IEnumerable<Permission> GetPermissions()
        {
            List<Permission> permissions = new List<Permission>();
            permissions.Add(new Permission() { Name = "UserCreate", Description = "创建", Category = "用户管理" });
            permissions.Add(new Permission() { Name = "UserEdit", Description = "修改", Category = "用户管理" });
            permissions.Add(new Permission() { Name = "UserDelete", Description = "删除", Category = "用户管理" });
            permissions.Add(new Permission() { Name = "UserAuth", Description = "审核", Category = "用户管理" });
            return permissions;
        }
    }
}