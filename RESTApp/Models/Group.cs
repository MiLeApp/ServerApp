﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<string> GroupUsers { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public bool Temporary { get; set; }

    }
}