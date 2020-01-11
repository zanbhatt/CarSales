using CarSales.DAL;
using CarSales.Models;
using CarSales.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarSales.Controllers
{
    public class HomeController : Controller
    {
        private IVehicleManager vehicleManager;
        public HomeController()
        {
            vehicleManager = new VehicleManager();
        }
        public HomeController(IVehicleManager _vehicleManager)
        {
            vehicleManager = _vehicleManager;
        }
        public ActionResult Index()
        {
            ViewBag.VehicleTypes = vehicleManager.GetTypes();
            ViewBag.Message = "";
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(VehicleType vehicle)
        {
            if (vehicle.Id == ((int)VehiclesType.Car))
                return RedirectToAction("Create", "Cars");
            else
            {   
                ViewBag.VehicleTypes = vehicleManager.GetTypes(); 
                ViewBag.Message = "This feature is not available.";
                return View("Index");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}