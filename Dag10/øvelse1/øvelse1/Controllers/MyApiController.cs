using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace øvelse1.Controllers
{
    public class MyApiController : Controller
    {



        public ActionResult ReturnPerson()
        {
            List<String> data = new List<string>()
            {
                "my string 2","my string 3",
                "my string 1","my string 5"
            };

            ViewBag.Data = data;

            ViewBag.Message = "Your application description page.";

            return View();
        }


        public string TalkToMyDemo()
        {
            return "TalkToMyDemo()";
        }




        public String MyArgAction(String name, int id, int age)
        {

            return HttpUtility.HtmlEncode($"PersonRoute({name},{id},{age})");
           //return View();


        }

    }
}

