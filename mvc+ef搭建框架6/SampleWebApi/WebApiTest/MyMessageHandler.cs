using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiTest
{
    /// <summary>
    /// 消息handler。继承webapi管道handle
    /// </summary>
    public class MyMessageHandler : DelegatingHandler
    {
        private static int counter = 0;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //添加一个自定义的计数器，如果计算器大于100.就停止访问。可以做收费接口的限制，以及一个pi在多少s之内只能访问多少次的限制

            request.Headers.Add("x-custom-heander", (++counter).ToString());
            return base.SendAsync(request, cancellationToken);
        }
    }
}
