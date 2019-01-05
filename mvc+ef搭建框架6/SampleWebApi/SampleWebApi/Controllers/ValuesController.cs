using SampleWebApi.Filters;
using System.Collections.Generic;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    public class ValuesController : ApiController
    {

        [CustomExceptionFilterAttribute]
        public IEnumerable<string> Get()
        {
            //int a = 1;
            //int b = 0;
            //int c = a / b;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            //int a = 1;
            //int b = 0;
            //int c = a / b;
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
