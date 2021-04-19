using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1.DataContext;
using ClassLibrary1.Model;
using ClassLibrary1.ViewModel;

namespace WebApplication2.Controllers
{
    public class ReservationsController : Controller
    {
        private RentServiceDBContext db = new RentServiceDBContext();

        // GET: Reservations
        public ActionResult Index()
        {
            String CusId = this.HttpContext.Session["email"].ToString(); 
            if(CusId != null)
            {
                var reservations = db.Reservations.Where(r => r.CustomerId.Equals(CusId)).Include(r => r.Customer).Include(r => r.Tool);
                return View(reservations.ToList());
            }

            return RedirectToAction("Index", "Home");
            
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Email", "Name");
            ViewBag.ToolId = new SelectList(db.Tools, "ToolId", "Name");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StartDate,EndDate,ToolId,Price")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.StorageStatus = 0;
                reservation.CustomerId = Session["email"].ToString();
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ToolId = new SelectList(db.Tools, "ToolId", "Name", reservation.ToolId);
            return View(reservation);
        }

        [HttpPost]
        public double CalculatePrice(PriceModel model)
        {
            using (RentServiceDBContext db = new RentServiceDBContext())
            {
                Tool selectedTool = db.Tools.Find(model.ToolID);
                int difference = (model.EndDate - model.StartDate).Days;
                double calculatedPrice = difference * selectedTool.PricePrDay;

                return calculatedPrice;

            }
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Email", "Name", reservation.CustomerId);
            ViewBag.ToolId = new SelectList(db.Tools, "ToolId", "Name", reservation.ToolId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResId,StartDate,EndDate,StorageStatus,ToolId,Price,CustomerId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Email", "Name", reservation.CustomerId);
            ViewBag.ToolId = new SelectList(db.Tools, "ToolId", "Name", reservation.ToolId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
