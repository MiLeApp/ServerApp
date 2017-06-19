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
            return BLManager.Instance.GetRide(id);
        }

        // POST: api/Ride
        public int Post(int GroupId, int driverId, List<int>acceptedUsersIds)
        {
            //create ride return id
            return BLManager.Instance.ReceiveRide(GroupId, driverId, acceptedUsersIds);
        }

        // PUT: api/Ride/5
        public void Put(int id, Ride ride)
        {
            //update ride
            BLManager.Instance.UpdateRide(id, ride);
        }

        // DELETE: api/Ride/5
        public void Delete(int id)
        {
            //delete ride
            BLManager.Instance.DeleteRide(id);
        }
    }
}
