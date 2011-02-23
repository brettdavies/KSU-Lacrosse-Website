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
        public ActionResult FAQ() { return View(); }
        public ActionResult History() { return View(); }
        public ActionResult Management() { return View(); }
        public ActionResult Media() { return View(); }

        [ActionName("owls-nest")]
        public ActionResult OwlsNest() { return View(); }

        [ActionName("media-guides")]
        public ActionResult MediaGuides() { return View(); }

        #region Deprecated ActionResults
        public ActionResult Contact() { return RedirectToAction("contact-us", "forms", null); }
        public ActionResult Facilities() { return RedirectToAction("owls-nest", "about", null); }
        #endregion Deprecated ActionResults

    }
}
