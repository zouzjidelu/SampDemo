using System.Web.Http.Filters;

namespace SampleWebApi.Filters
{
    /// <summary>
    /// 自定义异常处理类
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //这里可以返回异常处理返回给客户端的一些信息、状态、消息等
            actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}