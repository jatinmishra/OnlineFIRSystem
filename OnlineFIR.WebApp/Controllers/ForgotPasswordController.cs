using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFIR.WebApp.Models.EntityManager;
using System.Net.Mail;
using System.Configuration;
namespace OnlineFIR.WebApp.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        int ran_num = new Random().Next(1000, 90000);
        
        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult SendResetMail(string userid)
        {
            Session["resetcode"] = ran_num;
            sendResetCode("Password Reset Request", "Your password reset code is " + ran_num + " .", new FIRManager().getEmailIdFromUserId(userid));

            return RedirectToAction("ResetPasswordMail", "ResetPasswordMail");
        }
        public bool sendResetCode(string subject, string msg, string to)
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

    }
}