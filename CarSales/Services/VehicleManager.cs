using CarSales.DAL;
using CarSales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarSales.Services
{
    public class VehicleManager : IVehicleManager
    {
        private VehicleContext db = new VehicleContext();
        public List<SelectListItem> GetTypes()
        {
            var vehicleTypes = db.VehicleTypes;
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in vehicleTypes.ToList())
            {
                items.Add(new SelectListItem { Text = item.Type, Value = item.Id.ToString() });
            }

            return items;
        }
    }
}