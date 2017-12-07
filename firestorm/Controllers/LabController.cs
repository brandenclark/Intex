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

        public ActionResult ManageTickets()
        {
            var tickets = db.Tickets.Include(t => t.Priority).Include(t => t.User).Include(t => t.WorkOrder);
            return View(tickets.ToList());
        }

        public ActionResult ResolveTicket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.PriorityName = new SelectList(db.Priorities, "PriorityName", "PriorityName", ticket.PriorityName);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", ticket.UserID);
            ViewBag.OrderID = new SelectList(db.WorkOrders, "OrderID", "Comments", ticket.OrderID);
            return View(ticket);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResolveTicket([Bind(Include = "TicketID, DateSubmitted, DateResolved, PriorityName, OrderID, UserID, Comment, Response")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.DateResolved = DateTime.Now;

                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PriorityName = new SelectList(db.Priorities, "PriorityName", "PriorityName", ticket.PriorityName);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", ticket.UserID);
            ViewBag.OrderID = new SelectList(db.WorkOrders, "OrderID", "Comments", ticket.OrderID);
            return View(ticket);
        }
    }
}