using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NetSwagger
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_EndRequest()
        {
            //if (Context.Response.StatusCode == 404)
            //{
            //    bool isAjax = new HttpRequestWrapper(Context.Request).IsAjaxRequest();
            //    if (isAjax || Context.Request.Path.ToLower().IndexOf("/api") > -1)
            //    {
            //        Response.Write(Context.Request.RawUrl);
            //    }
            //    else
            //    {
            //        Response.RedirectToRoute("Default", new { controller = "Error", action = "Error404", errorUrl = Context.Request.RawUrl });
            //    }
            //}
        }
    }
}
