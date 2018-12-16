using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManager.Entitys
{
    /// <summary>
    /// 导航类
    /// </summary>
    public class Navigate : BaseEntity
    {
        /// <summary>
        /// 控制其名称
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// action名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 导航名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string IConClassCode { get; set; }

        /// <summary>
        /// 上级导航ID
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// 上级导航信息
        /// </summary>
        public Navigate Parent { get; set; }

        /// <summary>
        /// 是否活动中
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 子导航列表
        /// </summary>
        public ICollection<Navigate> Children { get; set; } = new List<Navigate>();

    }
}