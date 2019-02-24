using NetSwagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NetSwagger.Controllers.Brand
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
                new Product(){ID=1,Name="美迪惠尔",CreateTime=DateTime.Now},
                new Product(){ID=1,Name="Ray",CreateTime=DateTime.Now},
                new Product(){ID=1,Name="Sa",CreateTime=DateTime.Now},
            };
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <returns>返回产品列表</returns>
        public List<Product> GetProducts()
        {
            return products;
        }

        /// <summary>
        /// 根据产品id获取产品详细信息
        /// </summary>
        /// <param name="Id">产品id</param>
        /// <returns>产品详细信息</returns>
        public Product GetById(int Id)
        {
            return products.FirstOrDefault(u => u.ID == Id);
        }

        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <param name="user">产品信息</param>
        /// <returns>true：OK，false:error</returns>
        public bool Add(Product product)
        {
            products.Add(product);
            return true;
        }

        /// <summary>
        /// 根据产品id删除产品信息
        /// </summary>
        /// <param name="Id">产品标识id</param>
        /// <returns>true：OK，false:error</returns>
        public bool Delete(int Id)
        {
            Product product = products.FirstOrDefault(u => u.ID == Id);
            if (product == null)
            {
                return false;
            }

            return products.Remove(product);
        }
    }
}
