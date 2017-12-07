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
        static public WorkOrderCompoundSample workOrderCompoundSample;

        public ActionResult RequestOrderNumber()
        {
          

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "1", Value = "1", Selected = true });
            items.Add(new SelectListItem { Text = "2", Value = "2" });
            items.Add(new SelectListItem { Text = "3", Value = "3" });
            items.Add(new SelectListItem { Text = "4", Value = "4" });
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "6", Value = "6" });
            items.Add(new SelectListItem { Text = "7", Value = "7" });
            items.Add(new SelectListItem { Text = "8", Value = "8" });
            items.Add(new SelectListItem { Text = "9", Value = "9" });

            ViewBag.CompoundCount = items;
            return View("RequestOrderNumber");
        }

        [HttpPost]
        public ActionResult RequestOrderNumber(FormCollection form)
        {
            workOrderCompoundSample = new WorkOrderCompoundSample();
            int CompoundsNeeded = Int32.Parse(form["CompoundCount"]);
            int iCount = 0;
            List<SelectListItem> items = new List<SelectListItem>();
     

            items.Add(new SelectListItem { Text = "1", Value = "1" });
            items.Add(new SelectListItem { Text = "2", Value = "2" });
            items.Add(new SelectListItem { Text = "3", Value = "3" });
            items.Add(new SelectListItem { Text = "4", Value = "4" });
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "6", Value = "6" });
            items.Add(new SelectListItem { Text = "7", Value = "7" });
            items.Add(new SelectListItem { Text = "8", Value = "8" });
            items.Add(new SelectListItem { Text = "9", Value = "9" });

            List<SelectListItem> items2 = new List<SelectListItem>();


            items2.Add(new SelectListItem { Text = "1", Value = "1" });
            items2.Add(new SelectListItem { Text = "2", Value = "2" });
            items2.Add(new SelectListItem { Text = "3", Value = "3" });
            items2.Add(new SelectListItem { Text = "4", Value = "4" });
            items2.Add(new SelectListItem { Text = "5", Value = "5" });
            items2.Add(new SelectListItem { Text = "6", Value = "6" });
    

            foreach (var item in items)
            {
                if (Int32.Parse(item.Value) == CompoundsNeeded)
                {
                    item.Selected = true;
                }
            }

            ViewBag.CompoundCount = items;
            ViewBag.TestCount = items2;

            for (iCount = 0; iCount < CompoundsNeeded; iCount++)
            {
                workOrderCompoundSample.compoundSampleSampleTests.Add(new CompoundSampleSampleTest());
                
            }


            return View(workOrderCompoundSample);
        }


        [HttpPost]
        public ActionResult RequestOrderTests(FormCollection form)
        {


            return View();
        }



        public ActionResult RequestOrder(int? AssayCount)
        {
            WorkOrderCompoundSample workOrderCompoundSample = new WorkOrderCompoundSample();
            int iCount = 0;

            // Load up the amount of compound samples based on the assay tests
            for(iCount = 0; iCount < AssayCount; iCount ++)
           // workOrderCompoundSample.compoundSamples.Add(new CompoundSample());

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