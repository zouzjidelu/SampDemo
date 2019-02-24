using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetSwagger.Models
{
    /// <summary>
    /// 产品实体类
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 标识ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        public DateTime CreateTime { get; set; }
    }
}