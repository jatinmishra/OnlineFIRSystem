using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineFIR.WebApp.Models.EntityManager;
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.ViewModel;

namespace OnlineFIR.WebApp.Controllers
{
    public class AddStationController : Controller
    {
        FIRManager FM = new FIRManager();
        // GET: AddStation
        public ActionResult AddStation()
        {
            ViewBag.Visibility = "hidden";
            ViewBag.VisibilityE = "hidden";
            // ViewBag.Flag = "noReset";
            return View();
        }
        [HttpPost]
        public ActionResult AddStation(AddPoliceStation addPoliceStation)
        {
            ViewBag.Visibility = "hidden";
            ViewBag.VisibilityE = "hidden";
            if (ModelState.IsValid) {
                System.Threading.Thread.Sleep(1000);
                bool t=FM.createStation(addPoliceStation);
                // ViewBag.Success = "<div class='saveSuccess' align='center'><img src = '~/Content/Images/tick.jpg' style = 'max-height:50px; max-width:50px;'/>Police Station created successfully.</div> ";
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