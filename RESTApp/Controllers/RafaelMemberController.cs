using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTApp.Controllers
{
    public class RafaelMemberController : ApiController
    {
        // GET: api/RafaelMember
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RafaelMember/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RafaelMember
        public void Post(RafaelMember p_member)
        {
            BL.BLManager.Instance.AddRafaelMember(p_member);
        }

        // PUT: api/RafaelMember/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RafaelMember/5
        public void Delete(int id)
        {
        }
    }
}
