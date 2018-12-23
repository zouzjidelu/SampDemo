using ExceptionAndLogSapmle.Controllers;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExceptionAndLogSapmle.Exceptions
{
    /// <summary>
    /// 微软企业库异常处理类
    /// </summary>
    public class ExceptionHandlingAttribute : HandleErrorAttribute
    {
        public string ExceptionPolicyName { get; private set; }
        public ExceptionHandlingAttribute(string ExceptionPolicyName = "defaultPolicy")
        {
            this.ExceptionPolicyName = ExceptionPolicyName;
        }

        public override void OnException(ExceptionContext filterContext)
        {
            try
            {
                filterContext.ExceptionHandled = true;
                //处理异常
                ExceptionPolicy.HandleException(filterContext.Exception, ExceptionPolicyName);


                {//方式一：获取当前请求的aciton名称，跳转到对应的错误页面去，页面规则自己定，目前的错误action规则是  On{actionName}Error
                    string actionName = filterContext.RouteData.GetRequiredString("action");
                    string errAction = $"On{actionName}Error";
                    Controller controller = filterContext.Controller as Controller;
                    if (controller != null && controller.ActionInvoker.InvokeAction(filterContext, errAction))
                    {
                        filterContext.ExceptionHandled = true;
                    }
                }

                {//方式二：通过错误码，跳转到对应的错误页面
                    ////实例化一个http请求内发生的对象
                    //HttpException httpException = new HttpException(null, filterContext.Exception);

                    //RouteData routeData = new RouteData();
                    //string rediActionName = Enum.GetName(typeof(HttpStatusCode), httpException.GetHttpCode());
                    //routeData.Values.Add("Controller", "Error");
                    //routeData.Values.Add("Action", rediActionName);
                    //routeData.Values.Add("msg", filterContext.Exception);


                    //IController errorController = new ErrorController();
                    //RequestContext httpRequest = new RequestContext(filterContext.HttpContext, routeData);

                    //errorController.Execute(httpRequest);
                }


            }
            catch (Exception ex)
            {
                filterContext.Exception = ex;
                base.OnException(filterContext);
            }
        }
    }
}