using System;
using System.Net.Mail;
using System.Configuration;

namespace OnlineFIR.WebApp.Helpers
{
    public class EmailHelper
    {
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
            catch (Exception)
            {

                return false;
            }
        }
    }
}