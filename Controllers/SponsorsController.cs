using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Logic;
using KSULax.Models;
using KSULax.Models.Game;
using KSULax.Entities;

namespace KSULax.Controllers
{
    public class SponsorsController : Controller
    {
        private KSULaxEntities _entities;
        private GameBL _gamesBL;

        public SponsorsController()
        {
            _entities = new KSULaxEntities();
            _gamesBL = new GameBL(_entities);
        }

        public ActionResult Index()
        {
            GameListModel games = new GameListModel(_gamesBL.GamesBySeason(KSU.maxGameSeason));

            return View(games);
        }
    }
}
