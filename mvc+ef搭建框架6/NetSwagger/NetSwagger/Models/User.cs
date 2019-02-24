using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetSwagger.Models
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class User
    {
        /// <summary>
        /// 标识ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}