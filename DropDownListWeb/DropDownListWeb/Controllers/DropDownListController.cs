using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropDownListWeb.Models;

namespace DropDownListWeb.Controllers
{
    public class DropDownListController : Controller
    {
        // GET: DropDownList
        public ActionResult Index()
        {
            IEnumerable<SelectListItem> selectlist = new ObservableCollection<SelectListItem>();
            foreach (Postdistrikt p in Postdistrikt.Set)
            {

                SelectListItem item = new SelectListItem();
                item.Value = p.Postnr.ToString();
                item.Text = p.Bynavn;
                selectlist.Append(item);
            }
            ViewBag.postnumre = selectlist;
            Adresse a = new Adresse();
            return View(a);
        }

        [HttpPost]
        public ActionResult Index(Adresse a)
        {
            return View(a);
        }
    }
}