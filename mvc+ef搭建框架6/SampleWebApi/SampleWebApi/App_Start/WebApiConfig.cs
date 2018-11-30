using SampleWebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;

namespace SampleWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //扩展媒体类型映射。在api后加参数来返回具体的数据格式
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("format", "xml", "application/xml"));
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("format", "json", "application/json"));

            //自定义异常处理
            //config.Filters.Add(new CustomExceptionFilterAttribute());
            //自定义消息handle
            config.MessageHandlers.Add(new CustomMessageHandler());

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //using WebApiContrib.Formatting.Jsonp; 可以不用在方法中接收callback参数由此插件帮忙完成
            //config.AddJsonpFormatter();
            config.EnableCors();

        }
    }
}
