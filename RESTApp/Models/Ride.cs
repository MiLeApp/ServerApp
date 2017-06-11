using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApp.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string DriverId { get; set; }
        public DateTime DepartDate { get; set; }
    }
}