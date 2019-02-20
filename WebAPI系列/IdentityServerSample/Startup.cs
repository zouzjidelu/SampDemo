using IdentityServer3.AccessTokenValidation;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.InMemory;
using IdentityServerSample;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]
namespace IdentityServerSample
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //配置identityserver token验证
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://lcalhost:5000",
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new[] { "api1", "api2" }
            });

            //identityserver集成
            var options = new IdentityServerOptions()
            {
                Factory = new IdentityServerServiceFactory()
                .UseInMemoryClients(Clients.GetClients())
                .UseInMemoryUsers(new List<InMemoryUser>())
                .UseInMemoryScopes(Scopes.GetScopes()),
                RequireSsl=false,
                
            };
            app.UseIdentityServer(options);


            //api集成
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }
    }
}
