using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UserManager.Entitys
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [DefaultValue(true)]
        public bool Active { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}