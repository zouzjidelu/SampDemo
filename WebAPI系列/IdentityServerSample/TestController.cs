using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace IdentityServerSample
{
    [Route("test")]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var principal = User as ClaimsPrincipal;//主体
            return Json(new
            {
                message = "OK",
                client_id = principal.FindFirst("client_id").Value
            });
        }
    }
}
