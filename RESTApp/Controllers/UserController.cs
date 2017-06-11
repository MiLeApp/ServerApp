using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApp.Models;

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
            return new User() { Id = id};
        }

        // POST: api/User
        public string Post(User user)
        {
            //insert user
            //return user uid
            return "";
        }

        // PUT: api/User/5
        public void Put(int id, User user)
        {
            //update user
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            //delete user
        }
    }
}
