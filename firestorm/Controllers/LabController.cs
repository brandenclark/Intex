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
            IEnumerable<NewTestTube> test= db.Database.SqlQuery<NewTestTube>("SELECT [Assay.AssayID], [Assay.Name]," +
                "[CompoundSample.SequenceCode], [CompoundSample.LT], [CompoundSample.DateDue], [Test.TestID] " +
                "FROM [Assay], [Test], [CompoundSample], [AssayTest]" +
                "WHERE [Test.TestID] = [AssayTest.TestID] AND [AssayTest.AssayID] = [Assay.AssayID] " +
                "AND [Assay.AssayID] = [CompoundSample.AssayID]");
            return View(test);
        }
        //Edit
        public ActionResult CreateTTube(int? id, int? lt, int? sc, string asid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (lt == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (sc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (asid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test atest = db.Tests.Find(id);
            SampleTest newsampletest = new SampleTest();
            newsampletest.AssayID = asid;
            newsampletest.LT = lt;
            newsampletest.SequenceCode = sc;
            newsampletest.TestID = id ?? default(int);
            return View(newsampletest);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTTube([Bind(Include = "TestTubeID,ScheduledDate,Concentration,LT,SequenceCode,AssayID,TestID")] SampleTest test)
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