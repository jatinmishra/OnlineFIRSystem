using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.EntityManager;


namespace OnlineFIR.WebApp.Controllers
{
    public class DeletePoliceStationController : Controller
    {
        FIRManager FM = new FIRManager();
        // GET: DeletePoliceStation
        public ActionResult DeletePoliceStation()
        {
            ViewBag.ListStation = FM.getStationList();
            ViewBag.Visibility = "hidden";
            ViewBag.VisibilityE = "hidden";

            return View();
        }
        [HttpPost]
        public ActionResult deletePoliceStation(string stationId)
        {
            ViewBag.ListStation = FM.getStationList();
            ViewBag.Visibility = "hidden";
            ViewBag.VisibilityE = "hidden";
            bool t = FM.deleteStation(stationId);
            if (t) { ViewBag.Visibility = "visible"; return View(); }
            else { ViewBag.VisibilityE = "visible"; return View(); }

        }
    }
}