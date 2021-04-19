using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassParametersWeb.Controllers
{
    public class Parameters
    {
        public int? Param1 { get; set; }
        public int? Param2 { get; set; }
    }

    public class PostMapController : Controller
    {
        // GET: RouteMap
        public ActionResult Index()
        {
            Parameters p = new Parameters { Param1 = null, Param2 = null };
            return View(p);
        }

        [HttpPost]
        public ActionResult Index(Parameters p)
        {
            ViewBag.result = p.Param1 + p.Param2;
            return View(p);
        }
    }
}