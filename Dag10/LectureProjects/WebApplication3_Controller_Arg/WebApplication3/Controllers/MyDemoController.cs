using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class MyDemoController : Controller
    {
        // GET: MyDemo
        // public ActionResult Index()
        // {
        //     return View();
        // }

        public string Index() {
            return "View()";
        }

        public string TalkToMyDemo() {
            return "TalkToMyDemo()";
        }

        public string Arg1ToMyDemo(int arg1, string arg2="arg2") {
            return HttpUtility.HtmlEncode($"Arg1ToMyDemo({arg1},{arg2})");
        }

        public string IDToMyDemo(int id, int arg=1) {
            return $"IDToMyDemo({id},{arg})";
        }

        public string RouteTest(string option, int ID, int arg = 1) {
            return HttpUtility.HtmlEncode($"RouteTest({option},{ID},{arg})");
        }
    }
}