using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspApp.Models;

namespace AspApp.Controllers
{
    public class PersonSetsController : Controller
    {
        private PersonsEntities db = new PersonsEntities();

        // GET: PersonSets
        public ActionResult Index()
        {
            return View(db.PersonSet.ToList());
        }

        // GET: PersonSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonSet personSet = db.PersonSet.Find(id);
            if (personSet == null)
            {
                return HttpNotFound();
            }
            return View(personSet);
        }

        // GET: PersonSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Weight,Score,Accepted")] PersonSet personSet)
        {
            if (ModelState.IsValid)
            {
                db.PersonSet.Add(personSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personSet);
        }

        // GET: PersonSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonSet personSet = db.PersonSet.Find(id);
            if (personSet == null)
            {
                return HttpNotFound();
            }
            return View(personSet);
        }

        // POST: PersonSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Weight,Score,Accepted")] PersonSet personSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personSet);
        }

        // GET: PersonSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonSet personSet = db.PersonSet.Find(id);
            if (personSet == null)
            {
                return HttpNotFound();
            }
            return View(personSet);
        }

        // POST: PersonSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonSet personSet = db.PersonSet.Find(id);
            db.PersonSet.Remove(personSet);
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
