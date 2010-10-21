using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Models;

namespace KSULax.Controllers
{
    [HandleError]
    public class NewsController : Controller
    {
        KSULaxEntities entities;

        public NewsController() { entities = new KSULaxEntities(); }

        public ActionResult Index(int? year, int? month, int? day, string url_title)
        {
            if (!year.HasValue && !month.HasValue && !day.HasValue && string.IsNullOrEmpty(url_title))
            {
                ViewData.Model = NewsList(1000);
                return View();
            }
            
            DateTime storyDate;
            List<News> Stories = new List<News>();

            if (DateTime.TryParse(year.ToString() + "/" + month.ToString() + "/" + day.ToString(), out storyDate))
            {
                if (!string.IsNullOrEmpty(url_title))
                {
                    Stories = Story(storyDate, url_title);

                    if (Stories.Count > 0) { ViewData.Model = Stories.ElementAt<News>(0); }
                    else { throw new Exception("KSULAX||we can't find the the story you requested"); }

                    return View("Story");
                }

                else
                {
                    Stories = NewsYearMonthDay(storyDate);
                    if (Stories.Count > 0)
                    {
                        ViewData.Model = Stories;
                        return View("Search");
                    }
                    else { throw new Exception("KSULAX||we don't have any stories from " + storyDate.ToShortDateString()); }
                }
            }

            else
            {//must check if exists then in nested check if it is valid (check month/day) or not (throw exception)
                //if the year is valid
                if (year.HasValue && year.Value >= 2006 && year.Value <= DateTime.Now.Year)
                {
                    //if the month is valid
                    if (month.HasValue && month.Value >= 1 && month.Value <= 12)
                    {
                        //if the day is valid
                        if (day.HasValue && day.Value >= 1 && day.Value <= DateTime.DaysInMonth(year.Value, month.Value))
                        { Stories = NewsYearMonthDay(new DateTime(year.Value, month.Value, day.Value)); }
                        else
                        { Stories = NewsYearMonth(new DateTime(year.Value, month.Value, 1)); }
                    }
                    else
                    { Stories = NewsYear(new DateTime(year.Value, 1, 1)); }
                }
                else
                {
                    throw new Exception("KSULAX||"+year.GetValueOrDefault() + "/" +
                        month.GetValueOrDefault() + "/" +
                        day.GetValueOrDefault() + " is not a valid date.");
                }
                
                if (Stories.Count > 0)
                {
                    ViewData.Model = Stories;
                    return View("Search");
                }
                else
                { throw new Exception("KSULAX||there aren't any stories in the range you specified"); }
            }
        }

        public List<News> Story(DateTime storyDate, string url_title)
        {
            return (entities.NewsSet
                      .Where("it.date = CAST('" + storyDate + "' as System.DateTime)")
                      .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                      .Where("it.url_title like '" + Server.HtmlEncode(url_title) + "'")
                      .OrderBy("it.date desc")
                      .ToList());
        }

        public List<News> NewsList(int numStories)
        {
            List<News> news = new List<News>(
                entities.NewsSet
                  .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                  .OrderBy("it.date desc")
                  .Take(numStories)
                  .ToList());
            
            GamesController gc = new GamesController();
            news.AddRange(gc.GameListNewsList(gc.GameSummary(numStories)));

            news.Sort((x, y) => DateTime.Compare(y.date, x.date));
            return news.GetRange(0, (news.Count < numStories) ? news.Count : numStories );
        }

        public List<News> NewsYear(DateTime date)
        {
            List<News> news = new List<News>
                (entities.NewsSet
                  .Where("it.date BETWEEN CAST('" + date + "' as System.DateTime)" +
                        "AND CAST('" + date.AddYears(1) + "' as System.DateTime)")
                  .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                  .OrderBy("it.date desc")
                  .ToList());

            GamesController gc = new GamesController();
            news.AddRange(gc.GameListNewsList(gc.GameSummaryYear(date)));

            news.Sort((x, y) => DateTime.Compare(y.date, x.date));
            return news;
        }

        public List<News> NewsYearMonth(DateTime date)
        {
            List<News> news = new List<News>
                (entities.NewsSet
                  .Where("it.date BETWEEN CAST('" + date + "' as System.DateTime)" +
                        "AND CAST('" + date.AddMonths(1) + "' as System.DateTime)")
                  .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                  .OrderBy("it.date desc")
                  .ToList());

            GamesController gc = new GamesController();
            news.AddRange(gc.GameListNewsList(gc.GameSummaryYearMonth(date)));

            news.Sort((x, y) => DateTime.Compare(y.date, x.date));
            return news;
        }

        public List<News> NewsYearMonthDay(DateTime date)
        {
            List<News> news = new List<News>
                (entities.NewsSet
                  .Where("it.date BETWEEN CAST('" + date + "' as System.DateTime)" +
                        "AND CAST('" + date.AddDays(1) + "' as System.DateTime)")
                  .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                  .OrderBy("it.date desc")
                  .ToList());

            GamesController gc = new GamesController();
            news.AddRange(gc.GameListNewsList(gc.GameSummaryYearMonthDay(date)));

            news.Sort((x, y) => DateTime.Compare(y.date, x.date));
            return news;
        }
    }
}
