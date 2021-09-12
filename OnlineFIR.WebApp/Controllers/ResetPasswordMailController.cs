using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFIR.WebApp.Controllers
{
    public class ResetPasswordMailController : Controller
    {
        // GET: ResetPasswordMail
        public ActionResult ResetPasswordMail()
        {
            return View();
        }

        public ActionResult ResetPasswordMail(string resetcode,string npass,string cpass)
        {
            if (resetcode != null && npass != null)
            {
                if (npass != cpass)
                {
                    ViewBag.Msg = "Entered passwords do not match.";
                    return View();
                }
                else if (resetcode.Equals(Session["resetcode"].ToString()))
                {
                    ViewBag.Msg = "Your password has been succesfully changed. You can login again with your new password.";
                }
            }
            return View();
        }
    }
}