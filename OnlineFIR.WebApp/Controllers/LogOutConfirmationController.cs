using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFIR.WebApp.Controllers
{
    public class LogOutConfirmationController : Controller
    {
        // GET: LogOutConfirmation
        public ActionResult LogOutConfirmation()
        {
            ViewBag.v = "hidden";
            return View();
        }
        [HttpPost]
        public ActionResult LogOutConfirmation(string i)
        {
            Session.Clear();
            ViewBag.v = "visible";
            return View("LogOutConfirmation");
            
        }
    }
}