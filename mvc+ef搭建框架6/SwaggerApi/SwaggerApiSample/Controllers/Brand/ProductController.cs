using SwaggerApiSample.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
namespace SwaggerApiSample.Controllers.Brand
{
    /// <summary>
    /// 产品控制器类
    /// </summary>
    public class ProductController : ApiController
    {
        private readonly static List<Product> products;
        static ProductController()
        {
            products = new List<Product>()
            {
                new Product(){ ID=1,Name="产品1",CreateTime=DateTime.Now},
                new Product(){ ID=2,Name="产品2",CreateTime=DateTime.Now},
                new Product(){ ID=3,Name="产品3",CreateTime=DateTime.Now},
                new Product(){ ID=4,Name="产品4",CreateTime=DateTime.Now},
                new Product(){ ID=5,Name="产品5",CreateTime=DateTime.Now}
            };
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public List<Product> GetList()
        {
            return products;
        }

        /// <summary>
        /// 根据产品id获取产品详细信息
        /// </summary>
        /// <param name="ID">标识ID</param>
        /// <returns></returns>

        [HttpGet]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public Product GetProductById(int ID)
        {
            return products.FirstOrDefault(u => u.ID == ID);
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="Product">产品对象</param>
        /// <returns>true：成功，false：失败</returns>
        [HttpPost]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public bool AddProduct(Product Product)
        {
            products.Add(Product);
            return true;
        }

        /// <summary>
        /// 根据产品id删除产品信息
        /// </summary>
        /// <param name="ID">标识id</param>
        /// <returns>true：成功，false：失败</returns>
        [HttpGet]
        [ApiAuthor(Name = "常帅", Status = DevStatus.Finish, Time = "2019-01-05")]
        public bool Delete(int ID)
        {
            var Product = products.FirstOrDefault(u => u.ID == ID);
            if (Product == null)
            {
                return false;
            }
            return products.Remove(Product);
        }
    }
}
