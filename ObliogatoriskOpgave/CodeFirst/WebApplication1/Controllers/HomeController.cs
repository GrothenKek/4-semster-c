using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst.DataContext;
using CodeFirst.Model;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private RentServiceContext db = new RentServiceContext();


        public class Parameters
        {
            public String Email { get; set; }
            public String Password { get; set; }
        }

        public ActionResult Index()
        {
            Parameters p = new Parameters { Email = null, Password = null };
            return View(p);
        }
        [HttpPost]
        public ActionResult Index(Parameters p)
        {
            var userLogin = db.Customers.Single(c => c.Email.Equals(p.Email) && c.Password.Equals(p.Password));

            if(userLogin != null)
            {
                Session["email"] = userLogin.Email;

                return RedirectToAction("Index","Customers", userLogin);

            }
            else
            {
                return View(p);
            }

    }




        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("index");
        }

    }
}




