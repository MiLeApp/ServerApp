using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTApp.Controllers
{
    public class GoogleApiController : ApiController
    {
        // GET: api/GoogleApi
        public IEnumerable<string> Get()
        {
            new GoogleAPI.GoogleApiClient().DisCoveryService();
            return new string[] { "value1", "value2" };
        }

        // GET: api/GoogleApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GoogleApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GoogleApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GoogleApi/5
        public void Delete(int id)
        {
        }
    }
}
