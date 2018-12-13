using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManager.Entitys
{
    /// <summary>
    /// 实体权限
    /// </summary>
    public class EntityPermission
    {
        public int EntityID { get; set; }

        public string EntityName { get; set; }

        public int RoleID { get; set; }

        public virtual Role Role { get; set; }

    }

}