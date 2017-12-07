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
        static public User user;
        static public List<int> iTest;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestOrderNumber()
        {
            user = db.Users.Find(Int32.Parse(Request.Cookies["UserID"].Value));

            workOrderCompoundSample = new WorkOrderCompoundSample();

            workOrderCompoundSample.workOrder = new WorkOrder();
            workOrderCompoundSample.compound = new Compound();


            workOrderCompoundSample.workOrder.Discount = 0;
            workOrderCompoundSample.workOrder.CompanyID = user.CompanyID.Value;

            workOrderCompoundSample.workOrder.OrderID = db.WorkOrders.ToList().Max(x => x.OrderID) + 1;

            //Create compound and assign the number
            workOrderCompoundSample.compound.LT = db.Compounds.ToList().Max(x => x.LT) + 1;

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
           
            int CompoundsNeeded = Int32.Parse(form["CompoundCount"]);
            int iCount = 0;
            List<SelectListItem> items = new List<SelectListItem>();
            workOrderCompoundSample.compound.Name = form["compound.Name"];

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
                workOrderCompoundSample.compoundSampleSampleTests.ElementAt(iCount).compoundSample = new CompoundSample();
                workOrderCompoundSample.compoundSampleSampleTests.ElementAt(iCount).compoundSample.OrderID = workOrderCompoundSample.workOrder.OrderID;
                workOrderCompoundSample.compoundSampleSampleTests.ElementAt(iCount).compoundSample.LT = workOrderCompoundSample.compound.LT;
                workOrderCompoundSample.compoundSampleSampleTests.ElementAt(iCount).compoundSample.SequenceCode = db.CompoundSamples.Max(x => x.SequenceCode) + 1;
            }


            return View(workOrderCompoundSample);
        }


        [HttpPost]
        public ActionResult RequestOrderTests(FormCollection form)
        {
            List<string> sTests = form["TestCount"].Split(',').ToList();
            iTest = new List<int>();
            int iCount = 0;
            int iCount1 = 0;

            foreach (var Test in sTests)
            {
                iTest.Add(Int32.Parse(Test));
            }
            

            foreach (var Compound in workOrderCompoundSample.compoundSampleSampleTests)
            {
                for(iCount = 0; iCount < iTest.ElementAt(iCount1); iCount++ )
                {
                    Compound.sampleTests.Add(new SampleTest());
                }
                iCount1++;
            }
            return RedirectToAction("RequestOrder", "Customer");
        }









        public ActionResult RequestOrder()
        {
            int iCount = 0;

         

            ViewBag.Assays = db.Assays.ToList();

            return View(workOrderCompoundSample);
        }

        [HttpPost]
        public ActionResult RequestOrder(FormCollection form)
        {
            /*Weight
             *DateDue
             *AssayID
             * Comments
             */
            List<string> sAssays = form["AssayID"].Split(',').ToList();
            int iCount = 0;
            int iCount1 = 0;
            int iCount2 = 0;
            
            foreach(var Compound in workOrderCompoundSample.compoundSampleSampleTests)
            { 
                Compound.compoundSample.DateDue = Convert.ToDateTime(form["DateDue"]);
                Compound.sampleTests.Clear();
                for (iCount = 0; iCount < iTest.ElementAt(iCount1); iCount++)
                    {
                        Compound.compoundSample.AssayID = sAssays.ElementAt(iCount);
                        var Tests = db.Database.SqlQuery<AssayTest>("SELECT * FROM AssayTest WHERE AssayID = '" + Compound.compoundSample.AssayID +"'").ToList();

                        for (iCount2 = 0; iCount2 < Tests.Count(); iCount2++)
                        {
                            Compound.sampleTests.Add(new SampleTest());
                            Compound.sampleTests.ElementAt(iCount).LT = workOrderCompoundSample.compound.LT;
                            Compound.sampleTests.ElementAt(iCount).SequenceCode = Compound.compoundSample.SequenceCode;
                            Compound.sampleTests.ElementAt(iCount).TestTubeID = db.SampleTests.Max(x => x.TestTubeID) + 1;
                        }
                      
                }
                iCount1++;
            }


            
            workOrderCompoundSample.workOrder.Comments = form["workOrder.Comments"];
            

            return RedirectToAction("Confirmation", new {Name = user.FirstName });
        }


        public ActionResult Confirmation(string Name)
        {
            ViewBag.Name = Name;
            return View();
        }
        public ActionResult TrackOrder()
        {
            return View();
        }
    }
}