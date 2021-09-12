using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.EntityManager;


namespace OnlineFIR.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            ViewBag.VisibilityI = "hidden";
            return View();
        }
        [HttpPost]
        public ActionResult showFIRListByID(string firID)
        {
            // ViewBag.VisibilityE = "hidden";
            if (!firID.Equals(null))
            {
                if (new FIRManager().checkValidFIRID(firID))
                {
                    Session["firID"] = firID;
                    return RedirectToAction("FIRDetails", "FIRDetails");
                }
                else
                    ViewBag.VisibilityI = "visible";
                //new FIRListController().showFIRDetails(firID);
            }



            return View();

        }
        public ActionResult showFIRListByStatus(string selStatus)
        {
            ViewBag.VisibilityI = "hidden";
            if (!selStatus.Equals(null))
            {
                Session["selStatus"] = selStatus;
                return RedirectToAction("FIRList", "FIRList");
            }
            return View();
        }
    }
}