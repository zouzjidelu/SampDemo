using NetSwagger.Selectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace NetSwagger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // Web API 配置和服务
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
              name: "AdminApi",
              routeTemplate: "api/Admin/{controller}/{action}/{id}",
              defaults: new
              {
                  action = RouteParameter.Optional,
                  id = RouteParameter.Optional,
                  namespaces = new string[] { "NetSwagger.Controllers.Admin" }
              });
            config.Routes.MapHttpRoute(
                name: "BrandApi",
                routeTemplate: "api/Brand/{controller}/{action}/{id}",
                defaults: new
                {
                    action = RouteParameter.Optional,
                    id = RouteParameter.Optional,
                    namespaces = new string[] { "NetSwagger.Controllers.Brand" }
                });

        }
    }
}
