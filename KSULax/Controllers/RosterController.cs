using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using KSULax.Dal;
using KSULax.Models.Roster;

namespace KSULax.Controllers
{
    [HandleError]
    public class RosterController : Controller
    {
        private KSULaxEntities _entities;

        public RosterController()
        {
            _entities = new KSULaxEntities();

        }

        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "roster", new { id = KSU.maxPlayerSeason });
            }

            int gsID = id.Value;

            if (gsID >= 2007 && gsID <= KSU.maxPlayerSeason)
            {
                RosterModel rm = new RosterModel();
                rm.SeasonID = gsID;

                return View(rm);
            }

            else
            {
                throw new Exception("KSULAX||we can't find the roster you requested");
            }
        }
    }
}
