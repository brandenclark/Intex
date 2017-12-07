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
        public ActionResult DisplayTests()
        {
            var test = db.SampleTests;
            return View(test.ToList());
        }
        //GET: SampleTest/Details
        public ActionResult ScheduleTest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleTest test = db.SampleTests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }
        //GET SampleTest/Edit
        public ActionResult TestEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleTest test = db.SampleTests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestTubeID,Concentration,LT,SequenceCode,AssayID,TestID")] SampleTest test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }
        public ActionResult UpdateTest()
        {
            return View();
        }
    }
}