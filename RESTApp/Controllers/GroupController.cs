using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApp.Models;

namespace RESTApp.Controllers
{
    public class GroupController : ApiController
    {
        // GET: api/Group
        public IEnumerable<Group> Get()
        {
            //return all groups
            List<Group> groups = new List<Group>();
            return groups;
        }

        // GET: api/Group/5
        public Group Get(int id)
        {
            return new Group() { Id = id};
        }

        // POST: api/Group
        public string Post(Group group)
        {
            //create new group
            //return group uid
            return "";
        }

        // PUT: api/Group/5
        public void Put(int id, Group group)
        {
            //update group
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
            //delete group
        }
    }
}
