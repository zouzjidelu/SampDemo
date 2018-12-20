using ExceptionAndLogSapmle.App_Start;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System;
using System.Net;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(ErrorHandlingActivator), "Start")]
namespace ExceptionAndLogSapmle.App_Start
{
    /// <summary>
    /// 异常处理激活器
    /// </summary>
    public static class ErrorHandlingActivator
    {
        public static void Start()
        {
            //动态注册HttpMoudle
            DynamicModuleUtility.RegisterModule(typeof(ErrorHandlingStartupModule));
        }
    }


    //实现httpmodel，http管道模型
    public class ErrorHandlingStartupModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.Error += Context_Error;
        }

        private void Context_Error(object sender, System.EventArgs e)
        {
            HttpApplication httpApplication = (HttpApplication)sender;
            //获得异常信息
            Exception exception = httpApplication.Server.GetLastError();
            //实例化一个http请求内发生的对象
            HttpException httpException = new HttpException(null, exception);
            //http相应状态码
            if (httpException.GetHttpCode() == (int)HttpStatusCode.NotFound)
            {

            }

        }
    }
}