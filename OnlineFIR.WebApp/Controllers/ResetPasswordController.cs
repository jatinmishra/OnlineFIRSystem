using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.EntityManager;

namespace OnlineFIR.WebApp.Controllers
{
    public class ResetPasswordController : Controller
    {
        // GET: ResetPassword
        public ActionResult ResetPassword()
        {
            ViewBag.t = "";
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(string uID, string oldPass, string newPass)
        {
            if (new FIRManager().resetPassword(uID, oldPass, newPass))
            {
                ViewBag.t = "success";
                return View();
            }
            else
            {
                ViewBag.t = "error";
                return View();
            }
        }
    }
}