using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApp.BL
{
    public class UserNotification
    {
        private List<Object> notifObjects = new List<object>();
        public int OpCode { get; set; }
        public List<Object> NotificationObj
        {
            get
            {
                return notifObjects;
            }
            set
            {
                notifObjects = value;
            }
        }
               
    }
}