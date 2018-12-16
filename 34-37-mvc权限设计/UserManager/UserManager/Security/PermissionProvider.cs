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
            List<Permission> permissions = new List<Permission>()
            {
                //new Permission() { Name = "UserCreate", Description = "创建", Category = "用户管理" },
                // new Permission() { Name = "UserGet", Description = "查看", Category = "用户管理" },
                //new Permission() { Name = "UserEdit", Description = "修改", Category = "用户管理" },
                //new Permission() { Name = "UserDelete", Description = "删除", Category = "用户管理" },
                //new Permission() { Name = "UserAuth", Description = "审核", Category = "用户管理" },
                //new Permission() { Name = "RoleEdit", Description = "创建", Category = "角色管理" },
                // new Permission() { Name = "RoleCreate", Description = "修改", Category = "角色管理" },
                //  new Permission() { Name = "NewsCreate", Description = "创建", Category = "新闻管理" }
                 new Permission() { Name = "ManagerIndex", Description = "查看", Category = "管理首页" }

            };
            return permissions;
        }
    }
}