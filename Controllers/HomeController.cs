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
            HomepageData homedata = new HomepageData();
            GamesController gc = new GamesController();

            homedata.games = gc.GamesList(KSU.maxGameSeason);
            homedata.Stories = GetStoryModels(_newsBL.NewsList(6), this.Request.Url.ToString());

            ViewData.Model = homedata;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetRanking()
        {
            List<Ranking> ranking = new List<Ranking>(3);
            ranking.Add(RecentRankingbyPollID(1));
            ranking[0].datestr = ranking[0].date.ToString("MMMM dd, yyyy");
            ranking.Add(RecentRankingbyPollID(2));
            ranking[1].datestr = ranking[1].date.ToString("MMMM dd, yyyy");
            ranking.Add(RecentRankingbyPollID(3));
            ranking[2].datestr = ranking[2].date.ToString("MMMM dd, yyyy");

            return this.Json(ranking, JsonRequestBehavior.AllowGet);
        }

        private Ranking RecentRankingbyPollID(int pollID)
        {
            var result = from Rank in _entities.PollSet.Where("it.pollsource_id = " + pollID).OrderBy("it.date desc").Take(1)
                         select new Ranking
                         {
                             pollSource = Rank.pollsource_id,
                             date = Rank.date,
                             rank = Rank.rank,
                             rankUrl = Rank.url
                         };

            return result.First<Ranking>();
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