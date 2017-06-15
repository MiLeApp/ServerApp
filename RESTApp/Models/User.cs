using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string IdFB { get; set; }
        public string PhoneNum { get; set; }
        public string NickName{ get; set; }
        public int Mileage { get; set; }
    }
}