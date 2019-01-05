﻿using Newtonsoft.Json;
using SwaggerApiSample;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Swagger.Demo.Api
{
    public class ApiResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //action 请求上下文
            var at = actionExecutedContext.ActionContext;

            //ActionContext 返回结果为空时,说明出现异常,则走异常处理过滤器
            if (at.Response == null)
            {
                return;
            }


            //POST,DELETE,PUT需要封装返回结果
            if (at.Request.Method != HttpMethod.Get)
            {
                AjaxResult result = new AjaxResult();
                result.type = ResultType.success;
                result.resultdata = at.Response.Content != null ? at.Response.Content.ReadAsStringAsync().Result : "";

                at.Response = new HttpResponseMessage(HttpStatusCode.OK);
                //actionExecutedContext.Response.Content = new StringContent(JsonConvert.ToString(result));
                string jsonStr = JsonConvert.SerializeObject(result);
                actionExecutedContext.Response.Content = new StringContent(jsonStr);
            }
        }
    }
}
