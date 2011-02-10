using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Models;
using KSULax.Logic;
using KSULax.Models.News;
using KSULax.Entities;
using KSULax.Models.Home;
using KSULax.Models.Game;

namespace KSULax.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private KSULaxEntities _entities;
        private NewsBL _newsBL;
        private GameBL _gameBL;

        public HomeController()
        {
            _entities = new KSULaxEntities();
            _newsBL = new NewsBL(_entities);
            _gameBL = new GameBL(_entities);
        }

        public ActionResult Index()
        {
            HomepageDataModel homedata = new HomepageDataModel();

            homedata.games = new GameListModel(_gameBL.GamesBySeason(KSU.maxGameSeason));
            homedata.Stories = new StoryListModel(_newsBL.NewsList(6), this.Request.Url.ToString());

            return View(homedata);
        }
    }
}