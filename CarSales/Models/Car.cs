using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public string Engine { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public int BodyTypeId { get; set; }
                
        public virtual Make Make { get; set; }
        public virtual Model Model { get; set; }
        public virtual BodyType BodyType { get; set; }
    }
}