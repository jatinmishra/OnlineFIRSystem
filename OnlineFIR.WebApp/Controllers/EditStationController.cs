using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineFIR.WebApp.Models.EntityManager;
using OnlineFIR.WebApp.Models.ViewModel;
using System.Web.Mvc;

namespace OnlineFIR.WebApp.Controllers
{
    public class EditStationController : Controller
    {
        FIRManager FM = new FIRManager();
        // GET: EditStation
        public ActionResult EditStation()
        {
            ViewBag.Visibility = "hidden";
            ViewBag.VisibilityE = "hidden";
            if (Session["userId"] != null)
            {
                return View(FM.getStationDetails(FM.getStationIdFromUserId(Session["userId"].ToString()))[0]);
            }
            else if (Session["userId"] != null) { 

            }
            return View();
        }

        [HttpPost]
        public ActionResult EditStation(EditPoliceStation editPoliceStation)
        {
            editPoliceStation.user_id = Session["userId"].ToString();
            editPoliceStation.station_id = FM.getStationIdFromUserId(Session["userId"].ToString());
            ViewBag.Visibility = "hidden";
            ViewBag.VisibilityE = "hidden";
           // if (ModelState.IsValid)
            { 
                bool t = FM.editStation(editPoliceStation);
                if (t)
                {
                    ViewBag.Visibility = "visible";
                    ViewBag.Flag = "reset";
                }
                else
                { ViewBag.VisibilityE = "visible"; }
                return View();
            }

            return View();

        }
    }
}