using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using RESTApp.Models;
using RESTApp.BL;

namespace RESTApp.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<User> Get()
        {
            IList<User> users = new List<User>();
            return users;
        }

        // GET: api/User/5
        public User Get(int id)
        {
            //return user by id
            return BLManager.Instance.GetUser(id);
        }

        // POST: api/User
        public int Post(User user)
        {
            //insert user
            //return user uid
            return BLManager.Instance.AddNewUser(user);
        }

        // PUT: api/User/5
        public void Put(int id, User user)
        {
            //update user
            BLManager.Instance.UpdateUser(id, user);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            //delete user
            BLManager.Instance.DeleteUser(id);
        }
    }
}
