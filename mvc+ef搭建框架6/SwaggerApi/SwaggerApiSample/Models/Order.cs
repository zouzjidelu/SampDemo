using System;

namespace SwaggerApiSample.Models
{
    /// <summary>
    /// 订单信息类
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 标识ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}