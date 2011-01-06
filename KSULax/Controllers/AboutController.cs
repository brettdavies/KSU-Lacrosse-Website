using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Models;
using System.Net.Mail;

namespace KSULax.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index() { return View(); }
        public ActionResult Alumni() { return View(); }
        public ActionResult Associations() { return View(); }
        public ActionResult Facilities() { return View(); }
        public ActionResult FAQ() { return View(); }
        public ActionResult History() { return View(); }
        public ActionResult Management() { return View(); }
        public ActionResult Media() { return View(); }
        
        [ActionName("media-guides")]
        public ActionResult MediaGuides() { return View(); }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Contact()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact(ContactUsFormModel emailModel)
        {
            if (!ModelState.IsValid) { return View(); }

            else
            {
                try
                {
                    //Setup MailMessage
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(emailModel.Email, emailModel.Name);
                    msg.ReplyTo = msg.From;
                    msg.To.Add(new MailAddress("ksulacrosse@gmail.com", "KSU Lacrosse"));
                    msg.Subject = emailModel.Subject;
                    string body = "Name: " + emailModel.Name + "\n"
                                + "Company Name: " + emailModel.CompanyName + "\n"
                                + "Email: " + emailModel.Email + "\n"
                                + "Phone: " + emailModel.Phone + "\n\n"
                                + emailModel.Comments;

                    msg.Body = body;
                    msg.IsBodyHtml = false;

                    //Setup SMTPClient
                    SmtpClient client = new SmtpClient();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("ksulaxwebsite@gmail.com", "ksuowlslax");
                    
                    //Send the Email
                    client.Send(msg);

                    msg.Dispose();

                    MessageModel rcpt = new MessageModel();
                    rcpt.Title = "Thanks " + emailModel.Name + "!";
                    rcpt.Content = "We appreciate you taking the time to get in contact with us. We will do our best to be in touch with you quickly.";
                    return View("Message", rcpt);
                }

                catch (Exception)
                {
                    //Show an error
                    MessageModel err = new MessageModel();
                    err.Title = "Email Error";
                    err.Content = "The website is having an issue with sending email at this time. Sorry for the inconvenience.";
                    return View("Message", err);
                }
            }
        }
    }
}
