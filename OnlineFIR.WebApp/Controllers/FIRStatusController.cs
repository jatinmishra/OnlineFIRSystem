
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.EntityManager;

namespace OnlineFIR.WebApp.Controllers
{
    public class FIRStatusController : Controller
    {
        // GET: FIRStatus
        public ActionResult FIRStatus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FIRStatus(string firID)
        {
            string res = new FIRManager().CheckStatus(firID);
            if (!res.Equals(""))
            {
                if (res.Equals("0"))
                {
                    ViewBag.Pending = "The FIR is pending";
                }
                else if (res.Equals("1"))
                {
                    ViewBag.InProcess = "The FIR is in process";
                }
            }
            else
                ViewBag.Error = "Error retrieving in status , Please check the FIR ID and try again.";

            return View();
        }
    }
}