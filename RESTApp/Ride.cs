//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RESTApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ride
    {
        public int RideId { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<int> Distance { get; set; }
        public Nullable<int> DriverId { get; set; }
    }
}
