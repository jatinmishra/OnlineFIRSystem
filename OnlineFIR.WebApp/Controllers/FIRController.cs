using System;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OnlineFIR.WebApp.Models.ViewModel;
using OnlineFIR.WebApp.Models.EntityManager;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Net.Mail;
using System.Configuration;
using System.Linq;



namespace OnlineFIR.WebApp.Controllers
{
    public class FIRController : Controller
    {
        Random rand = new Random();
        public const string Alphabet =
        "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        FIRManager FM = new FIRManager();
        // GET: FIR
        public ActionResult RegisterFIR()
        {
            ViewBag.ListS= FM.getStationList();
            return View();
        }

        [HttpPost]
        public ActionResult RegisterFIR(AddFIRView addFIRView, HttpPostedFileBase file, string selStation)
        {
            if (ModelState.IsValid)
            {
                string fir_id_tmp;

                try
                {
                    if (file.ContentLength > 0 && addFIRView != null)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        DirectorySecurity securityRules = new DirectorySecurity();
                        securityRules.AddAccessRule(new FileSystemAccessRule(System.Security.Principal.WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl, AccessControlType.Allow));
                        Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/" + addFIRView.fir_complaintnee_name + addFIRView.fir_date), securityRules);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles/" + addFIRView.fir_complaintnee_name + addFIRView.fir_date), _FileName);
                        file.SaveAs(_path);
                        fir_id_tmp = FM.AddFir(addFIRView, _path, selStation);
                        if (fir_id_tmp != null)
                        {
                            sendEmail("Email Verification", "Your FIR has been successfully registered", addFIRView.email);
                            TempData["fir_complaintnee_name_tmp"] = addFIRView.fir_complaintnee_name;
                            TempData["fir_id_tmp"] = fir_id_tmp;
                            //ViewBag.fir_complaintnee_name_tmp= addFIRView.fir_complaintnee_name;
                            return RedirectToAction("RegistrationSuccess", "RegistrationSuccess");
                        }
                        else
                        {
                            ViewBag.Message = "One or more validation error occurred please check your entered details.";
                            ViewBag.ListS = FM.getStationList();
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "One or more validation error occurred please check your entered details.";
                        ViewBag.ListS = FM.getStationList();
                        return View();
                    }
                    // ViewBag.Message = "File Uploaded Successfully!!";                   
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Something went wrong please try again.";
                    ViewBag.ListS = FM.getStationList();
                    return View();
                }
                //FormsAuthentication.SetAuthCookie(addFIRView.FirstName, false);


            }
            ViewBag.Message = "Model state not valid.";
            ViewBag.ListS = FM.getStationList();
            return View();
        }
        //public bool verifyEmail(string email)
        //{
        //    bool t = sendEmail("Email Verification", GenerateString(5), email);
        //    if (t) { return true; }
        //    return false;
        //}

        public bool sendEmail(string subject, string msg, string to)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailFrom"]);
                mail.Subject = subject;
                mail.Body = msg;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["emailFrom"], ConfigurationManager.AppSettings["emailPassword"]);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        

        public string GenerateString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            return new string(chars);
        }

    }
    }
