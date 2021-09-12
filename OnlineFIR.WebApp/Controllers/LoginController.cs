using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.EntityManager;
using OnlineFIR.WebApp.Models.ViewModel;


namespace OnlineFIR.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        string user_id;

        Random randm = new Random();
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView lv)
        {
            char ch = new FIRManager().checkUserRole(lv.user_id, lv.user_password);
            if (ch.Equals('0'))
            {
                Session["userId"] = lv.user_id;
                // new FIRManager().sendSMS1();
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else if (ch.Equals('1'))
            { 
                return RedirectToAction("HQDashboard", "HQDashboard");
            }
            user_id = lv.user_id;
            return View();
        }
        public ActionResult SendResetMail()
        {
            return RedirectToAction("ForgotPassword", "ForgotPassword");
        }


    }
}
