using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.EntityManager;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;


namespace OnlineFIR.WebApp.Controllers
{
    public class FIRDetailsController : Controller
    {
        FIRManager FM = new FIRManager();
        // GET: FIRDetails
        public ActionResult FIRDetails()
        {
            if (Session["firID"] != null)
            {
                Models.DB.getSingleFIR_Result f = FM.getSingleFIR(Session["firID"].ToString())[0];
                return View(f);
            }
            else
            return View("UnauthorisedAccess");
        }

        public ActionResult updateStatus(string status)
        {
            if (status != null)
            {
                FM.updateFIRStatus(Session["firID"].ToString(), status);
                return RedirectToAction("FIRDetails", "FIRDetails");

            }
            return RedirectToAction("FIRDetails", "FIRDetails");
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string div)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                StringReader sr = new StringReader(div);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
    }
}