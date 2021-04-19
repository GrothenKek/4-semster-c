using CodeFirst.DataContext;
using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst.veiwModels;

namespace WebApplication1.Controllers
{
    public class ReservationsController : Controller
    {
        private RentServiceContext db = new RentServiceContext();


        public ActionResult Create()
        {
           
            
            ViewBag.Tools = new SelectList(db.Tools, "ToolId", "Name");

            Reservation res = new Reservation();
           

            return View(res);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StartDate,EndDate,ToolId,Price")] Reservation reservations)
        {
            if (ModelState.IsValid)
            {
                reservations.StorageStatus = 0;
                reservations.CustomerId = Session["email"].ToString();
                
                db.Reservations.Add(reservations);
                db.SaveChanges();
                return RedirectToAction("Details","Customers", db.Customers);
            }
            ViewBag.Email = new SelectList(db.Customers, "Email", "Name", reservations.CustomerId);
            return RedirectToAction("Details", "Customers", db.Customers); ;
        }

        [HttpPost]
        public double CalculatePrice(PriceModel model)
        {
            using (RentServiceContext db = new RentServiceContext())
            {
                Tool selectedTool = db.Tools.Find(model.ToolID);
                int difference = (model.EndDate - model.StartDate).Days;
                double calculatedPrice = difference * selectedTool.PricePrDay;

                return calculatedPrice;

            }
        }

        // GET: Reservations/Edit/5
       

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
