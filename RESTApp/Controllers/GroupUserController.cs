using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using RESTApp.BL;
using RESTApp.Models;

namespace RESTApp.Controllers
{
    public class GroupUserController : ApiController
    {
       

        // GET: api/Person
        public IEnumerable<string> Get()
        {
            
            List<string> namesList = new List<string>();

            string query = "SELECT Name FROM Contacts";
           

                return namesList;
        }

        // GET: api/Person/5
        public GroupUser Get(int groupId, int userId)
        {
            return BLManager.Instance.GetGroupUser(groupId, userId);
        }

        // POST: api/Person
        //Stam
        public void Post(int groupId, GroupUser userObj)
        {
            BLManager.Instance.AddNewGroupUser(groupId, userObj);
        }

        // PUT: api/Person/5
        public void Put(int groupId, GroupUser userObj)
        {
            BLManager.Instance.UpdateGroupUser(groupId, userObj);
        }

        // DELETE: api/Person/5
        public void Delete(int groupId, int userId)
        {
            BLManager.Instance.DeleteGroupUser(groupId, userId);
        }
    }
}
