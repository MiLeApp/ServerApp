﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApp.BL;

namespace RESTApp.Controllers
{
    public class GroupUserController : ApiController
    {
        // GET: api/GroupUser
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Person/5
        public GroupUser Get(int groupId, int userId)
        {
            return BLManager.Instance.GetGroupUser(groupId, userId);
        }

        // GET: api/GroupUser/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GroupUser
        public int Post(Contacts p_contacts)
        {
            return BLManager.Instance.AddNewGroupUsersList(p_contacts.GroupId, p_contacts.PhoneNumbers);
        }

        // PUT: api/GroupUser/5
        public void Put(int p_groupId, GroupUser p_user)
        {
            BLManager.Instance.UpdateGroupUser(p_groupId, p_user);
        }

        // DELETE: api/GroupUser/5
        public void Delete(int groupId, int userId)
        {
            BLManager.Instance.DeleteGroupUser(groupId, userId);
        }

        public class Contacts
        {
            public int GroupId { get; set; }
            public List<string> PhoneNumbers { get; set; }
        }
    }
}
