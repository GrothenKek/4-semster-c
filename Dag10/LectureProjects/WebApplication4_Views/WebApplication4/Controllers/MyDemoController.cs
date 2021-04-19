using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class MyDemoController : Controller
    {
        // GET: MyDemo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataIndex() {
            List<string> data = new List<string>() {
                "My string 1",
                "My string 2",
                "My string 3",
                "My string 4"
            };
            ViewBag.Data = data;
            return View();
        }
    }
}