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
    [Authorize(Users = "Management")]
    public class ManagementController : Controller
    {
        private Thunderstorm db = new Thunderstorm();

        // GET: Management
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SummaryReport()
        {
            var SumRpts = db.Database.SqlQuery<String>("SELECT wo.OrderID FROM SummaryReport sr RIGHT JOIN WorkOrder wo ON sr.OrderID = wo.OrderID "
                                    + "INNER JOIN CompoundSample cs ON cs.OrderID = wo.OrderID "
                                    + "INNER JOIN SampleTest st ON st.LT = cs.LT AND st.SequenceCode = cs.SequenceCode "
                                    + "WHERE st.CompletedTest = 1 AND wo.OrderID NOT IN("
                                    + "SELECT wo.OrderID FROM WorkOrder wo INNER JOIN CompoundSample cs ON cs.OrderID = wo.OrderID"
                                    + " INNER JOIN SampleTest st ON st.LT = cs.LT AND st.SequenceCode = cs.SequenceCode"
                                    + "WHERE st.CompletedTest = 0) AND sr.OrderID IS NULL GROUP BY wo.OrderID").ToList();

            return View(SumRpts);
        }
    }
}