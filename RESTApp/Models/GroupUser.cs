using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApp.Models
{
    public class GroupUser
    {
        public enum eUserRole { Driver=0,Passenger=1,None=2};
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public eUserRole Role { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Matched { get; set; }
    }
}