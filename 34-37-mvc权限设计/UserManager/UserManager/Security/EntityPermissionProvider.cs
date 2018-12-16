using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManager.Entitys;

namespace UserManager.Security
{
    /// <summary>
    /// 实体（数据）权限提供者（服务）接口
    /// </summary>
    public class EntityPermissionProvider : IEntityPermissionProvider
    {
        private UserManagerDbContext DbContext = new UserManagerDbContext();

        /// <summary>
        /// 当前实体是否有权限访问
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Authorize<T>(T entity) where T : BaseEntity
        {
            //获得当前用户的角色
            var Roles = WorkContext.CurrentUser.Roles.Where(r => r.Active).Select(r => r.ID);

            //获得实体权限列表中是否包含当前传入的实体
            //（实体权限id等于当前传入的验证实体的id并且实体名等于实体权限中的实体名称，并且当前实体权限中的角色id，在角色列表中存在）
            return DbContext.EntityPermissions.Any(ep => ep.EntityID == entity.ID && ep.EntityName == typeof(T).Name && Roles.Contains(ep.RoleID));
        }

    }
}