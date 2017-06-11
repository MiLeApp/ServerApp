using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApp.Models;

namespace RESTApp.Controllers
{
    public class RideController : ApiController
    {
        // GET: api/Ride
        public IEnumerable<Ride> Get()
        {
            return null;
        }

        // GET: api/Ride/5
        public Ride Get(int id)
        {
            return new Ride() { Id = id};
        }

        // POST: api/Ride
        public string Post(Ride ride)
        {
            //create ride return id
            return "";
        }

        // PUT: api/Ride/5
        public void Put(int id, Ride ride)
        {
            //update ride
        }

        // DELETE: api/Ride/5
        public void Delete(int id)
        {
            //delete ride
        }
    }
}
