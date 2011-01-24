using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Models;

namespace KSULax.Controllers
{
    public class SponsorsController : Controller
    {
        public ActionResult Index()
        {
            HomepageDataModel homedata = new HomepageDataModel();

            GamesController gc = new GamesController();
            homedata.games = gc.GamesList(KSU.maxGameSeason);

            ViewData.Model = homedata;

            return View();
        }
    }
}
