using System;

namespace SwaggerApiSample.Models
{
    /// <summary>
    /// 产品信息类
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 标识ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 产品名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}