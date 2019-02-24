using NetSwagger.Selectors;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

[assembly: PreApplicationStartMethod(typeof(NetSwagger.App_Start.SwaggerConfig), "Register")]
namespace NetSwagger.App_Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration.EnableSwagger(c =>
            {
                //配置简单API文档信息-用于单个文档
                c.SingleApiVersion("Admin", "海选名品管理员后台API")
                .Contact(x =>
                {
                    x.Email("550992499@qq.com");
                    x.Name("ivy");
                    x.Url("www.baidu.com");
                }).TermsOfService("ivy-常帅")
                .License(lb =>
                {
                    lb.Name("ivy-常帅");
                    lb.Url("www.baidu.com");
                }).Description("管理员后台管理Api");

                //c.MultipleApiVersions(ResolveAreasSupportByRouteConstraint, (vc) =>
                //{
                //    vc.Version("v1", "Common API", true).Description("登录，公共服务")
                //    .Contact(x =>
                //    {
                //        x.Name("2018").Email("nj_ybxie@sina.com").Url("https://www.cnblogs.com/xyb0226/");
                //    }); ;

                //    vc.Version("Bms", "基础资料 API").Description("基础数据");
                //    vc.Version("Mes", "生产管理 API").Description("生产管理");
                //});


                //多版本api控制，
                //c.MultipleApiVersions(ResolveAreasSupportByRouteConstraint, vc =>
                //{
                //    vc.Version("Admin", "海选名品管理员后台API")
                //    .Description("管理员后台管理Api")
                //    .TermsOfService("www.baidu.com")
                //    .License((lb) =>
                //    {
                //        lb.Name("ivy-常帅");
                //        lb.Url("www.baidu.com");
                //    });

                //    vc.Version("Brand", "海选名片品牌商后台API")
                //    .Contact(cb =>
                //    {
                //        cb.Name("ivy-常帅");
                //        cb.Email("550992499@qq.com");
                //        cb.Url("www.baidu.com");
                //    });

                //});

                //c.ApiKey("Authorization").Description("OnAuth2").In("header").Name("Authorization");
                //c.OAuth2("jwt").AuthorizationUrl("http://localhost:9460/oauth/token")
                //    .TokenUrl("http://localhost:9460/oauth/token").Scopes(
                //        x =>
                //        {
                //            x.Add("scope", "admin");
                //        });

                //增加token至请求头部
                c.ApiKey("Authorization").Description("token 唯一值").In("header").Name("Authorization");

                //xml描述文档
                //c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", Assembly.GetExecutingAssembly().GetName().Name+".xml"));
                c.IncludeXmlComments(string.Format("{0}/bin/NetSwagger.XML", AppDomain.CurrentDomain.BaseDirectory));
                

                //增加Swagger区域选择
                c.DocumentFilter<SwaggerAreasSupportDocumentFilter>();

                //显示开发者信息
                c.ShowDeveloperInfo();

                //添加上传操作过滤器
                //c.OperationFilter<AddUploadOperationFilter>();
            })
            .EnableSwaggerUi("apis/{*assetPath}", configure =>
             {
                 configure.InjectStylesheet(typeof(SwaggerConfig).Assembly, "NetSwagger.Swagger.theme-flattop.css");
                 configure.InjectJavaScript(typeof(SwaggerConfig).Assembly, "NetSwagger.Swagger.translator.js");
                 configure.EnableApiKeySupport("Authorization", "header");
             });

        }

        private static bool ResolveAreasSupportByRouteConstraint(ApiDescription apiDescription, string targetApiVersion)
        {
            if (targetApiVersion == "v1")
            {
                return apiDescription.Route.RouteTemplate.StartsWith("api/Controller");
            }

            var routeTemplateStart = "api/" + targetApiVersion;
            return apiDescription.Route.RouteTemplate.StartsWith(routeTemplateStart);
        }

    }
}