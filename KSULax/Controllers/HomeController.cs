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

namespace KSULax.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private KSULaxEntities _entities;
        private NewsBL _newsBL;

        public HomeController()
        {
            _entities = new KSULaxEntities();
            _newsBL = new NewsBL(_entities);
        }

        public ActionResult Index()
        {
            HomepageDataModel homedata = new HomepageDataModel();
            GamesController gc = new GamesController();

            homedata.games = gc.GamesList(KSU.maxGameSeason);
            homedata.Stories = GetStoryModels(_newsBL.NewsList(6), this.Request.Url.ToString());

            ViewData.Model = homedata;

            return View();
        }

        protected List<StoryModel> GetStoryModels(List<NewsBE> news, string requestUrl)
        {
            var Stories = new List<StoryModel>();

            foreach (var story in news)
            {
                Stories.Add(new StoryModel(story, requestUrl));
            }

            return Stories;
        }
    }
}