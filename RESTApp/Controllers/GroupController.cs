using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApp.Models;

using RESTApp.BL;

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
            return BLManager.Instance.GetGroup(id);
        }

        // POST: api/Group
        public int Post(Group group)
        {
            //create new group
            //return group uid
            
            return BLManager.Instance.AddNewGroup(group); ;
        }

        // PUT: api/Group/5
        public void Put(int id, Group group)
        {
            //update group
            BLManager.Instance.UpdateGroup(id, group);
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
            //delete group
            BLManager.Instance.DeleteGroup(id);
        }
    }
}
