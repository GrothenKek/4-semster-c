using ClassLibrary1.DataContext;
using ClassLibrary1.Model;
using ClassLibrary1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private RentServiceDBContext db = new RentServiceDBContext();
        public ActionResult Index()
        {
            
            var session = this.HttpContext.Session;
            object SessionEmail = session["email"];
            if(SessionEmail != null)
            {
                string cusId = SessionEmail.ToString();
                Customer c1 = db.Customers.Where(c => c.Email.Equals(cusId)).FirstOrDefault();
                if(c1 != null){

                  return View(c1);

                }


            }
            return RedirectToAction("login");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel login)
        {
            Customer loggedIn = db.Customers.Single(c => c.Email.Equals(login.Email) && c.Password.Equals(login.Password));
            if(loggedIn != null)
            {
                Session["email"] = loggedIn.Email;
                return View("Index", loggedIn);
            }
            return View();

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Name,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                
              
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}