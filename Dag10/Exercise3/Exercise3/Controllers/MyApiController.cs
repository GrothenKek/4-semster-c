using Exercise3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise3.Controllers
{
    public class MyApiController : Controller
    {
        // GET: MyApi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FancyPage() {            
            return View();
        }

        public ActionResult DataPage(int id=0, string name = "unknown", int age = 0) {
            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.Age = age;
            return View();
        }

        public ActionResult ModelDataPage(int id = 0, string name = "unknown", int age = 0) {
            // Id, Name, Age, Weight, Score, Accepted
            var p = new Person($"{id};{name};{age};54;5;False");
            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.Age = age;
            return View(p);
        }

        public string MyAction() {
            return "Result from MyAction";
        }

        public string MyIdAction(int id) {
            return $"Result from MyIdAction(id={id})";
        }

        public string MyArgAction(int id, string name, int age) {
            return $"Result from MyArgAction : id={id}, name={name}, age={age}";
        }

    }
}