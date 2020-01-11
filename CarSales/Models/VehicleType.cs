using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
    public enum VehiclesType
    {
        Car = 1,
        Boat = 2,
        Bus = 3
    }
}