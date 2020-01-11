using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarSales.DAL;
using CarSales.Models;

namespace CarSales.Controllers
{
    public class CarsController : Controller
    {
        private VehicleContext db = new VehicleContext();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.BodyType).Include(c => c.Make).Include(c => c.Model);
            return View(cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "Id", "Type");
            ViewBag.MakeId = new SelectList(db.Makes, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult GetModels(int makeId)
        {
            var models = db.Models.Where(x => x.MakeId == makeId).ToList();
            var modelsList = new SelectList(models, "Id", "Name");
            return Json(modelsList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetBodyTypes(int makeId)
        {
            var types = db.BodyTypes.Where(x => x.MakeId == makeId).ToList();
            var typesList = new SelectList(types, "Id", "Type");
            return Json(typesList, JsonRequestBehavior.AllowGet);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleTypeId,MakeId,ModelId,Engine,Doors,Wheels,BodyTypeId")] Car car)
        {
            if (ModelState.IsValid)
            {
                car.VehicleTypeId = (int)VehiclesType.Car;
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "Id", "Type", car.BodyTypeId);
            ViewBag.MakeId = new SelectList(db.Makes, "Id", "Name", car.MakeId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name", car.ModelId);
            ViewBag.VehicleType = VehiclesType.Car;
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "Id", "Type", car.BodyTypeId);
            ViewBag.MakeId = new SelectList(db.Makes, "Id", "Name", car.MakeId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name", car.ModelId);
            ViewBag.VehicleType = VehiclesType.Car;
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleTypeId,MakeId,ModelId,Engine,Doors,Wheels,BodyTypeId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "Id", "Type", car.BodyTypeId);
            ViewBag.MakeId = new SelectList(db.Makes, "Id", "Name", car.MakeId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name", car.ModelId);
            
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
