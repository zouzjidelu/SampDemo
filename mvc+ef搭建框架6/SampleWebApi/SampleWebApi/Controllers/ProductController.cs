using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    /// <summary>
    /// 产品控制器
    /// </summary>
    public class ProductController : ApiController
    {
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        [Route("products")]
        public IHttpActionResult Get()
        {
            if (Thread.CurrentThread.CurrentCulture.Name == "de-DE")
            {
                return Ok("I am German product!");
            }

            return Ok("I am English product!");
        }
    }
}
