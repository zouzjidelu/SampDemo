using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace SampleWebApi.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                type = "string",
                required = true,
                //@enum = new[] { "en-GB", "de-DE" }
            });

            //if (!apiDescription.ActionDescriptor.GetCustomAttributes<CultureAwareAttribute>().Any())
            //{
            //    return;
            //}
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CultureHandler : DelegatingHandler
    {
        private static readonly string[] _acceptedCultures = { "en-GB", "de-DE" };
        private static readonly string _defaultCulture = "en-GB";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(_defaultCulture);

            if (request.Headers.AcceptLanguage != null)
            {
                foreach (var v in request.Headers.AcceptLanguage.OrderBy(al => al.Quality))
                {
                    if (_acceptedCultures.Contains(v.Value))
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo(v.Value);
                    }
                }
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}