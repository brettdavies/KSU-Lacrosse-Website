using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Models;
using KSULax.Models.Photo;
using KSULax.Models.News;
using KSULax.Logic;
using System.Web.Routing;
using KSULax.Models.Game;
using KSULax.Entities;

namespace KSULax.Controllers
{
    public class GamesController : Controller
    {
        private KSULaxEntities _entities;
        private GameBL _gamesBL;
        private PhotoBL _photoBL;

        public GamesController()
        {
            _entities = new KSULaxEntities();
            _gamesBL = new GameBL(_entities);
            _photoBL = new PhotoBL(_entities);
        }

        [HandleError]
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "games", new { id = KSU.maxGameSeason });
            }

            int gsID = id.Value;

            if (gsID >= 2006 && gsID <= KSU.maxGameSeason)
            {
                return Schedule(gsID);
            }

            else
            {
                return Meta(gsID);
            }
        }

        public ActionResult Schedule(int seasonID)
        {
            List<GameBE> gamesBELst = _gamesBL.GameScheduleBySeason(seasonID);
            List<PhotoGalleryBE> galleriesBELst = _photoBL.PhotoGalleriesBySeason(seasonID);

            GameScheduleModelList gsm = new GameScheduleModelList();
            gsm.GameSchedule = new List<GameScheduleModel>();

            foreach (GameBE gameBE in gamesBELst)
            {
                Dictionary<string, PhotographerModel> dict = new Dictionary<string, PhotographerModel>();

                foreach (PhotoGalleryBE gallery in galleriesBELst.Where(g => g.GameID == gameBE.ID))
                {
                    if (!dict.ContainsKey(gallery.PhotographerName))
                    {
                        dict.Add(gallery.PhotographerName, new PhotographerModel(gallery));
                    }

                    else
                    {
                        dict[gallery.PhotographerName].PhotoGalleries.Add(new PhotoGalleryModel(gallery));
                    }
                }

                gsm.GameSchedule.Add(new GameScheduleModel(new GameModel(gameBE), dict.Values.ToList()));
            }

            if (null != gsm)
            {
                return View(gsm);
            }

            else
            {
                throw new Exception("KSULAX||we can't find the season you requested");
            }
        }

        public ActionResult Meta(int gameID)
        {
            ViewData.Model = new StoryModel(_gamesBL.GameDetail(gameID), this.Request.Url.ToString());

            if (ViewData.Model != null)
            {
                return View("GameMeta");
            }

            else
            {
                throw new Exception("KSULAX||we can't find the game you requested");
            }
        }
    }
}
