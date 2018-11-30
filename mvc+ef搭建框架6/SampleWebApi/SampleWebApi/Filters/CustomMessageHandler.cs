using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SampleWebApi.Filters
{
    public class CustomMessageHandler : DelegatingHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("日志内容 Start");
            var response = await base.SendAsync(request, cancellationToken);
            Debug.WriteLine("日志内容 End");

            return response;

        }
    }
}