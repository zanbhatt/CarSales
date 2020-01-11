using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CarSales.Models;

namespace CarSales.DAL
{
    public class VehicleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var makes = new List<Make>
            {
            new Make{Id=1, Name="Audi"},
            new Make{Id=2,Name="BMW"},
            new Make{Id=3,Name="Ford"}
            };

            makes.ForEach(s => context.Makes.Add(s));
            context.SaveChanges();

            var models = new List<Model>
            {
            new Model{Id=1, MakeId=1,Name="80" },
            new Model{Id=2, MakeId=1,Name="90" },
            new Model{Id=3, MakeId=1,Name="A1" },
            new Model{Id=4, MakeId=2,Name="1 Series" },
            new Model{Id=5, MakeId=2,Name="1 Series M" },
            new Model{Id=6, MakeId=2,Name="2 Series" },
            new Model{Id=7, MakeId=3,Name="Bronco" },
            new Model{Id=8, MakeId=3,Name="Capri" },
            new Model{Id=9, MakeId=3,Name="Consual-Cortina" }
            };

            models.ForEach(s => context.Models.Add(s));
            context.SaveChanges();

            var vehicleTypes = new List<VehicleType>
            {
            new VehicleType{Id=1, Type="Car"},
            new VehicleType{Id=2, Type="Boat"},
            new VehicleType{Id=2, Type="Bus"}
            };
            vehicleTypes.ForEach(s => context.VehicleTypes.Add(s));
            context.SaveChanges();

            var bodyTypes = new List<BodyType>
            {
            new BodyType{Id=1, Type="Convertible", MakeId=1},
            new BodyType{Id=2, Type="Hatch", MakeId=1},
            new BodyType{Id=3, Type="Hatch", MakeId=2},
            new BodyType{Id=4, Type="Sedan", MakeId=3},
            };
            bodyTypes.ForEach(s => context.BodyTypes.Add(s));
            context.SaveChanges();
        }
    }
}