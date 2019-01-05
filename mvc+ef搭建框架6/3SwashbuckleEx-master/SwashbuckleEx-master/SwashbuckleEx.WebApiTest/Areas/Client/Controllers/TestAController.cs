﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SwashbuckleEx.WebApiTest.Areas.Client.Controllers
{
    /// <summary>
    /// 客户端测试 相关API
    /// </summary>
    public class TestAController:ApiController
    {
        /// <summary>
        /// 获取客户端Guid
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}