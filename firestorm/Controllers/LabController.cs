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
    //[Authorize(Users = "Lab")]
    public class LabController : Controller
    {
        // GET: Lab

        private Thunderstorm db = new Thunderstorm();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OperForecast()
        {
            return View();
        }
        //GET: CompoundSample/Create
        public ActionResult ScheduleTest()
        {
            ViewBag.LT = new SelectList(db.Compounds, "LT", "LT");
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayID");
            ViewBag.OrderID = new SelectList(db.WorkOrders, "OrderID", "OrderID");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ScheduleTest([Bind(Include = "LT,SequenceCode,QuantityMG,DateArrived,ReceivedBy,DateDue,Appearance,Weight,MolMass,AuthAddTest,ScheduledDate,AssayID,OrderID")] CompoundSample cs)
        {
            if (ModelState.IsValid)
            {
               // db.comAdd(cs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LT = new SelectList(db.Compounds, "LT","LT", cs.LT);
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "AssayID", cs.AssayID);
            ViewBag.OrderID = new SelectList(db.WorkOrders, "OrderID", "OrderID", cs.OrderID);
            return View(cs);
        }
        public ActionResult UpdateTest()
        {
            return View();
        }
    }
}