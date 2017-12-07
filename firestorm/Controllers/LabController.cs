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
    [Authorize(Users = "Lab")]
    public class LabController : Controller
    {
        // GET: Lab
        public ActionResult Index()
        {
            return View();
        }
    }
}