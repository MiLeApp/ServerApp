using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApp.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public int DriverId { get; set; }
        public int[] Users { get; set; }
        public float Distance { get; set; }

    }
}