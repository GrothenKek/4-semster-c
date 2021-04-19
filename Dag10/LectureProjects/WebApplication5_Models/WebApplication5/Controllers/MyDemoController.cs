using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class MyDemoController : Controller
    {
        // GET: MyDemo
        public ActionResult Index()
        {
            var data = new MyData { Id = 1, Name = "Simon", Time = DateTime.Now, Info = "Demo data", Value = 5.7 };
            return View(data);
        }
    }
}