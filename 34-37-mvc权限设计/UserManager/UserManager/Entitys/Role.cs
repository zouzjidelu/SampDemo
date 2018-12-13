using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UserManager.Entitys
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role:BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [DefaultValue(true)]
        public bool Active { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}