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
    public class HomeController : Controller
    {
        private Thunderstorm db = new Thunderstorm();

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();

            var currentUser = db.Database.SqlQuery<User>(
                            "Select * " +
                            "FROM [User] " +
                            "WHERE Email = '" + email + "' AND " +
                            "[Password] = '" + password + "'").First();

            email = db.Database.SqlQuery<Role>("SELECT * FROM Role WHERE RoleID = " + currentUser.RoleID).First().Name;

            if (currentUser.UserID > 0)
            {
                    FormsAuthentication.SetAuthCookie(email, rememberMe);

                    return RedirectToAction("Index", "Home");             
             }
            else
            {
                return View();
            }
        }
    }
}