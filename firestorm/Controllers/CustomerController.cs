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
 
    //[Authorize(Users = "Customer")]
    public class CustomerController : Controller
    {
        private Thunderstorm db = new Thunderstorm();
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

        public ActionResult RequestOrder(int AssayCount = 1)
        {
            WorkOrderCompoundSample workOrderCompoundSample = new WorkOrderCompoundSample();
            int iCount = 0;

            // Load up the amount of compound samples based on the assay tests
            for(iCount = 0; iCount < AssayCount; iCount ++)
            workOrderCompoundSample.compoundSamples.Add(new CompoundSample());

            ViewBag.Assays = db.Assays.ToList();

            return View(workOrderCompoundSample);
        }
        public ActionResult Confirmation()
        {
            return View();
        }
        public ActionResult TrackOrder()
        {
            User user = db.Users.Find(Convert.ToInt32(Request.Cookies["UserID"].Value));
            
            return View();
        }
    }
}