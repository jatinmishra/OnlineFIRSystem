using System;
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.EntityManager;
using PagedList;

namespace OnlineFIR.WebApp.Controllers
{
    public class FIRListController : Controller
    {
        FIRManager FM = new FIRManager();
        IPagedList<Models.DB.getFIRDetails_Result> list;
        
        // GET: StationAdmin
        public ActionResult FIRList(int? page)
        {
            ViewBag.ResEmpty = "false";
            int pageSize = 4;
            int pageIndex = 1;
            //if (page > 0) { showPagedList(page); }
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            if (Session["userId"] != null)
            {
                Session["paging"] = true;
                if (FM.getFIRResults(FM.getStationIdFromUserId(Session["userId"].ToString())).Count > 0)
                {
                    //ViewBag.firTable = FM.getFIRResults(FM.getStationIdFromUserId(Session["userId"].ToString()));
                    string t = Session["userId"].ToString();
                    //Session["userId"] = null;
                    list = FM.getFIRResults(FM.getStationIdFromUserId(t)).ToPagedList(pageIndex, pageSize);
                    return View(list);

                }
                else
                {
                    ViewBag.ResEmpty = "true";
                    return View();
                }

            }
            else if (Session["selStation"] != null)
            {
                Session["paging"] = true;
                if (FM.getFIRResults(Session["selStation"].ToString()).Count > 0)
                {
                    //ViewBag.firTable = FM.getFIRResults(Session["selStation"].ToString());
                    string t = Session["selStation"].ToString();
                    list = FM.getFIRResults(t).ToPagedList(pageIndex, pageSize);
                    //Session["selStation"] = null;
                    return View(list);
                }
                else
                {
                    ViewBag.ResEmpty = "true";
                    return View();
                }
            }
            else if (Session["selStatus"] != null)
            {
                Session["paging"] = true;
                if (FM.getFIRResultsFromStatus(Session["selStatus"].ToString()).Count > 0)
                {
                    string t = Session["selStatus"].ToString();
                    //Session["selStatus"] = null;
                    list = FM.getFIRResultsFromStatus(t).ToPagedList(pageIndex, pageSize);
                    return View(list);
                }
                else
                {
                    ViewBag.ResEmpty = "true";
                    return View();
                }
            }
            else
            {
                return View("UnauthorisedAccess");
            }

        }

        public ActionResult showFIRDetails(string firID)
        {
            if (!firID.Equals(null))
            {
                Session["firID"] = firID;
                return RedirectToAction("FIRDetails", "FIRDetails");
            }
            else
                return View();
        }


        //public ActionResult showPagedList(int? page)
        //{
        //    int pageSize = 4;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    //ViewBag.CurrentSort = sortOrder;
        //    //sortOrder = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;
        //    return View(list.ToPagedList(pageIndex, pageSize));
        //}
    }
}