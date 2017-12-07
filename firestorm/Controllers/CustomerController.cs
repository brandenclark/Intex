using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firestorm.Models;
using firestorm.DAL;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Security;

namespace firestorm.Controllers
{
    [Authorize(Users = "Customer")]
    public class CustomerController : Controller
    {
        public ActionResult RequestOrderNumber()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "1", Value = "1", Selected = true });
            items.Add(new SelectListItem { Text = "2", Value = "2" });
            items.Add(new SelectListItem { Text = "3", Value = "3" });
            items.Add(new SelectListItem { Text = "4", Value = "4" });
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "6", Value = "6" });

            ViewBag.AssayCount = items;
            return View();
        }

        [HttpPost]
        public ActionResult RequestOrderNumber(FormCollection form)
        {
            return RedirectToAction("RequestOrder", new { AssayCount = Int32.Parse(form["AssayCount"]) }  );
        }

        public ActionResult RequestOrder(int AssayCount = 0)
        {
            ViewBag.test = AssayCount;
            return View();
        }
        public ActionResult Confirmation()
        {
            return View();
        }
        public ActionResult TrackOrder()
        {
            return View();
        }
    }
}