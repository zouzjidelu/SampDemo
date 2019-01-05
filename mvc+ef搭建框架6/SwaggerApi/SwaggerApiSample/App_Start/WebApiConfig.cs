using Swagger.Demo.Api;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace SwaggerApiSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //配置Action权限过滤器
            config.Filters.Add(new HandlerAuthorizeAttribute());

            //配置异常处理过滤器
            config.Filters.Add(new HandlerExceptionAttribute());

            //配置Action动作结束过滤器
            config.Filters.Add(new ApiResultAttribute());

            // 命名空间支持
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            // Web API 路由
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
              name: "AdminApi",
              routeTemplate: "api/Admin/{controller}/{action}/{id}",
              defaults: new {  id = RouteParameter.Optional, action = RouteParameter.Optional, namespaces = new string[] { "SwaggerApiSample.Controllers.Admin" } }
              
          );
            
            config.Routes.MapHttpRoute(
                name: "BrandApi",
                routeTemplate: "api/Brand/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = RouteParameter.Optional, namespaces = new string[] { "SwaggerApiSample.Controllers.Brand" } }
            );

            config.Routes.MapHttpRoute(
                name: "WareHouseApi",
                routeTemplate: "api/WareHouse/{controller}/{action}/{id}",
                defaults: new {  id = RouteParameter.Optional, action = RouteParameter.Optional, namespaces = new string[] { "SwaggerApiSample.Controllers.WareHouse" } }
            );

            //前端用
            config.Routes.MapHttpRoute(
                name: "SellerApi",
                routeTemplate: "api/Seller/{controller}/{action}/{id}",
                defaults: new {  id = RouteParameter.Optional, action = RouteParameter.Optional, namespaces = new string[] { "SwaggerApiSample.Controllers.Seller" } }
            );
            config.Routes.MapHttpRoute(
                name: "MemberApi",
                routeTemplate: "api/Admin/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = RouteParameter.Optional, namespaces = new string[] { "SwaggerApiSample.Controllers.Member" } }
            );


            //管理员、代理商、品牌商、店家后台管理
            // config.Routes.MapHttpRoute(
            //    name: "ManageApi",
            //    routeTemplate: "api/Seller/{controller}/{action}",
            //    defaults: new { action = "Get", namespaces = new string[] { "SwaggerApiSample.Controllers.Admin" } },
            //    constraints: new { area = @"^[a-zA-Z]+$" }
            //);
        }
    }
}
