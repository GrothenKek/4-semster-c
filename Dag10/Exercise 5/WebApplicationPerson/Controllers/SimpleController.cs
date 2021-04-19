using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SimpleController : Controller
    {
        // GET: Simple
        public ActionResult Index()
        {
            return View();
        }
        public string TalkToMyDemo()
        {
            return "TalkToMyDemo()";
        }
        public string Arg1ToMyDemo(int arg1, string arg2 = "arg2")
        {
            return $"Arg1ToMyDemo({arg1},{arg2})";
        }
        public string RouteTest(string option, int ID, int arg = 1)
        {
            return HttpUtility.HtmlEncode($"RouteTest({option},{ID},{arg})");
        }
        public ActionResult DataIndex()
        {
            List<Person> plist = new List<Person>() {
                new Person() {ID=1, Name="Per" },
                new Person() {ID=2, Name="Pia" },
                new Person() {ID=3, Name="Poul" },
                new Person() {ID=4, Name="Pi" }
            };
            return View(plist);
        }

        public string Edit(string option, int id)
        {
            return $"Edit(option={option}, id={id})";
        }
        public string Delete(string option, int id)
        {
            return $"Delete(option={option}, id={id})";
        }
        public string Details(string option, int id)
        {
            return $"Details(option={option}, id={id})";
        }
        public string Create(string option)
        {
            return $"Create(option={option})";
        }
    }
}