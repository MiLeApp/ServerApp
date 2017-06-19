using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApp.BL;

namespace RESTApp.Controllers
{
    public class UserGroupsController : ApiController
    {
        // GET: api/UserGroups
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserGroups/5
        public List<Group> Get(int id)
        {
            return BLManager.Instance.GetUserGroups(id);
        }

        // POST: api/UserGroups
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserGroups/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserGroups/5
        public void Delete(int id)
        {
        }
    }
}
