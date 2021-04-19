using Exercise6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise6.Controllers {
    public class MyApiController : Controller {
        // GET: MyApi
        public ActionResult Index() {
            return View();
        }

        public ActionResult People() {
            var lst = new List<Person>() {
                new Person($"1;Tom;43;54;5;False"),
                new Person($"2;Pete;23;87;8;True"),
                new Person($"3;Eve;76;68;7;True")
            };
            return View(lst);
        }
    }
}