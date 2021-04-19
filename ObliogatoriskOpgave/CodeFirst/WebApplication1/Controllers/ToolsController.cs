using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst.DataContext;
using CodeFirst.Model;

namespace WebApplication1.Controllers
{
    public class ToolsController : Controller
    {
        private RentServiceContext db = new RentServiceContext();

        // GET: Tools
        public ActionResult Index()
        {
            return View(db.Tools.ToList());
        }

        // GET: Tools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tools = db.Tools.Find(id);
            if (tools == null)
            {
                return HttpNotFound();
            }
            return View(tools);
        }

        // GET: Tools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToolId,Name,Description,Status,PricePrDay")] Tool tools)
        {
            if (ModelState.IsValid)
            {
                db.Tools.Add(tools);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tools);
        }

        // GET: Tools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tools = db.Tools.Find(id);
            if (tools == null)
            {
                return HttpNotFound();
            }
            return View(tools);
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToolId,Name,Description,Status,PricePrDay")] Tool tools)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tools).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tools);
        }

        // GET: Tools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tools = db.Tools.Find(id);
            if (tools == null)
            {
                return HttpNotFound();
            }
            return View(tools);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tool tools = db.Tools.Find(id);
            db.Tools.Remove(tools);
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
