using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TAO_CSV_v06.Models;

namespace TAO_CSV_v06.Controllers
{
    public class SendMailerController : Controller
    {
        // GET: SendMailer
        
        public ActionResult Mailer(MailModel _objModelMail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(_objModelMail.To);
                    mail.From = new MailAddress(_objModelMail.From);
                    mail.Subject = _objModelMail.Subject;
                    string Body = _objModelMail.Body;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("artutest@hotmail.com", "20TesT20"); // Enter seders User name and password  
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return View("Mailer", _objModelMail);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception) {
                return View();
            }
        }
    }
}