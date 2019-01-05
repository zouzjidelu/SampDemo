using SwaggerApiSample.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
namespace SwaggerApiSample.Controllers.Member
{
    /// <summary>
    /// 订单控制器类
    /// </summary>
    public class OrderController : ApiController
    {
        private readonly static List<Order> Orders;
        static OrderController()
        {
            Orders = new List<Order>()
            {
                new Order(){ ID=1,OrderID="2018123101",CreateTime=DateTime.Now},
                new Order(){ ID=2,OrderID="2018123102",CreateTime=DateTime.Now},
                new Order(){ ID=3,OrderID="2018123103",CreateTime=DateTime.Now},
                new Order(){ ID=4,OrderID="2018123104",CreateTime=DateTime.Now},
                new Order(){ ID=5,OrderID="2018123105",CreateTime=DateTime.Now}
            };
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public List<Order> GetList()
        {
            return Orders;
        }

        /// <summary>
        /// 根据订单id获取订单详细信息
        /// </summary>
        /// <param name="orderID">订单号ID</param>
        /// <returns></returns>

        [HttpGet]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public Order GetOrderById(string orderID)
        {
            return Orders.FirstOrDefault(u => u.OrderID == orderID);
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="Order">订单对象</param>
        /// <returns>true：成功，false：失败</returns>
        [HttpPost]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public bool AddOrder(Order Order)
        {
            Orders.Add(Order);
            return true;
        }

        /// <summary>
        /// 根据订单id删除订单信息
        /// </summary>
        /// <param name="ID">标识id</param>
        /// <returns>true：成功，false：失败</returns>
        [HttpGet]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public bool Delete(int ID)
        {
            var Order = Orders.FirstOrDefault(u => u.ID == ID);
            if (Order == null)
            {
                return false;
            }
            return Orders.Remove(Order);
        }
    }
}
