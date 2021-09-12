using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.EntityManager;

namespace OnlineFIR.WebApp.Controllers
{
    public class HQDashboardController : Controller
    {
        // GET: HQDashboard
        public ActionResult HQDashboard()
        {
            //ViewBag.VisibilityE = "hidden";
            ViewBag.ListStation = new FIRManager().getStationList();
            
            ViewBag.VisibilityI = "hidden";
            return View();
        }

        [HttpPost]
        public ActionResult showFIRListByID(string firID)
        {
            Session["selStatus"] = null;
            Session["selStation"] = null;

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
     
        public ActionResult showFIRListByStationId(string selStation)
        {
            Session["selStatus"] = null;
            Session["firID"] = null;
        
            ViewBag.VisibilityI = "hidden";
            if (!selStation.Equals(null))
            {
                Session["selStation"] = selStation;
                return RedirectToAction("FIRList", "FIRList");
            }
            return View();
        }
      
        public ActionResult showFIRListByStatus(string selStatus)
        {
            Session["firID"] = null;
            Session["selStation"] = null;
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