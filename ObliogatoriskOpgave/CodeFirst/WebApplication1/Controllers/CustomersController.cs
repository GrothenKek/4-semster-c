
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst.DataContext;
using CodeFirst.Model;
using CodeFirst.viewModels;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private RentServiceContext db = new RentServiceContext();


        public ActionResult Index()
        {
            String sesString = Session["email"].ToString();
            Customer user = db.Customers.Find(sesString);


            return View(user);

        }

        public ActionResult Details()
        {
            
            if (ValidateCustomer.IsCustomerValid())
            {
                String sesString = Session["email"].ToString();
                Customer user = db.Customers.Find(sesString);
               
                return View(user);

            }
            else
                return RedirectToAction("Index","Home");
          
        }
    
        public ActionResult Create()
        {

            return View();
            
        }


    }
}
