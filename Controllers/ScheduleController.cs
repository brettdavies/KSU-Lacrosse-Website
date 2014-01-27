using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using KSULax.Dal;
using KSULax.Models.Schedule;

namespace KSULax.Controllers
{
    [HandleError]
    public class ScheduleController : Controller
    {
        private KSULaxEntities _entities;
        
        public ScheduleController()
        {
            _entities = new KSULaxEntities();

        }

        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "schedule", new { id = KSU.maxGameSeason });
            }

            int gsID = id.Value;

            if (gsID.Equals(2006))
            {
                return RedirectToAction("Index", "games", new { id = gsID });
            }

            if (gsID >= 2007)
            {
                ScheduleModel sm = new ScheduleModel();
                sm.SeasonID = gsID;

                return View(sm);
            }

            else
            {
                throw new Exception("KSULAX||we can't find the schedule you requested");
            }
        }
    }
}
