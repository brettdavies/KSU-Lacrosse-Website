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
    public class FormsController : Controller
    {
        /// <summary>
        /// Returns SMTPClient client configured with a SSL Gmail connection.
        /// </summary>
        /// <returns></returns>
        private SmtpClient smtpClient()
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("ksulaxwebsite@gmail.com", "ksuowlslax");

            return client;
        }

        /// <summary>
        /// Default error message
        /// </summary>
        /// <returns></returns>
        private MessageModel errorMessage()
        {
            MessageModel err = new MessageModel();
            err.Title = "Email Error";
            err.Content = "The website is having an issue with sending email at this time. Sorry for the inconvenience.";
            return err;
        }

        public ActionResult Index() { return RedirectToAction("winter-skills-clinic", "forms", null); }

        [ActionName("contact-us")]
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [ActionName("contact-us")]
        [HttpPost]
        public ActionResult Contact(ContactUsFormModel emailModel)
        {
            if (!ModelState.IsValid) { return View(); }

            else
            {
                try
                {
                    //Setup MailMessage
                    using (MailMessage msg = new MailMessage())
                    {
                        msg.From = new MailAddress(emailModel.Email, emailModel.Name);
                        msg.ReplyToList.Add(msg.From);
                        msg.To.Add(new MailAddress("ksulacrosse@gmail.com", "KSU Lacrosse"));
                        msg.Subject = emailModel.Subject;
                        string body = "Name: " + emailModel.Name + "\n"
                                    + "Company Name: " + emailModel.CompanyName + "\n"
                                    + "Email: " + emailModel.Email + "\n"
                                    + "Phone: " + emailModel.Phone + "\n\n"
                                    + emailModel.Comments;

                        msg.Body = body;
                        msg.IsBodyHtml = false;

                        //Send the Email
                        using (SmtpClient client = smtpClient())
                        {
                            client.Send(msg);
                        }
                    }

                    MessageModel rcpt = new MessageModel();
                    rcpt.Title = "Thanks " + emailModel.Name + "!";
                    rcpt.Content = "We appreciate you taking the time to get in contact with us. We will do our best to be in touch with you quickly.";
                    return View("Message", rcpt);
                }

                catch (Exception)
                {
                    //Show an error
                    MessageModel err = new MessageModel();
                    return View("Message", errorMessage());
                }
            }
        }

        [ActionName("player-registration")]
        [HttpGet]
        public ActionResult PlayerRegistration()
        {
            return View();
        }

        [ActionName("player-registration")]
        [HttpPost]
        public ActionResult PlayerRegistration(PlayerRegistrationModel emailModel)
        {
            if (!ModelState.IsValid) { return View(); }

            else
            {
                try
                {
                    string name = emailModel.FirstName + ' ' + emailModel.LastName;

                    //Setup MailMessage
                    using (MailMessage msg = new MailMessage())
                    {
                        msg.From = new MailAddress(emailModel.Email, name);
                        msg.ReplyToList.Add(msg.From);
                        msg.CC.Add(msg.From);
                        msg.To.Add(new MailAddress("ksulacrosse@gmail.com", "KSU Lacrosse"));
                        msg.Subject = emailModel.Subject;
                        string body = "Name: " + name + "\n"
                                    + "Email: " + emailModel.Email + "\n"
                                    + "Phone: " + emailModel.PhoneNumber + "\n"
                                    + "Position: " + emailModel.Position + "\n"
                                    + "USLaxID: " + emailModel.USLaxID + "\n"
                                    + "KSUID: " + emailModel.KSUID + "\n"
                                    + "Major: " + emailModel.Major + "\n"
                                    + "GPA: " + emailModel.GPA + "\n"
                                    + "Height: " + emailModel.Height + "\n"
                                    + "Weight: " + emailModel.Weight + "\n"
                                    + "Hometown: " + emailModel.Hometown + "\n"
                                    + "Homestate: " + emailModel.Homestate + "\n"
                                    + "Highschool: " + emailModel.Highschool + "\n"
                                    + "Highschoolyear: " + emailModel.Highschoolyear;

                        msg.Body = body;
                        msg.IsBodyHtml = false;

                        //Send the Email
                        using (SmtpClient client = smtpClient())
                        {
                            client.Send(msg);
                        }
                    }

                    MessageModel rcpt = new MessageModel();
                    rcpt.Title = "Thanks " + name + "!";
                    rcpt.Content = "Your registration has been submitted to the team. A copy has been emailed to you as well. Win it to be in it!";
                    return View("Message", rcpt);
                }

                catch (Exception)
                {
                    //Show an error
                    return View("Message", errorMessage());
                }
            }
        }

        [ActionName("winter-skills-clinic")]
        public ActionResult WinterSkillsClinic() { return View(); }
    }
}
