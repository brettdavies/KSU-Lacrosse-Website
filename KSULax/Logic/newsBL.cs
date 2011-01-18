using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;
using KSULax.Models;
using KSULax.Controllers;

namespace KSULax.Logic
{
    public class NewsBL
    {
        KSULaxEntities _entities;

        public NewsBL(KSULaxEntities entitity) { _entities = entitity; }

        /// <summary>
        /// Gets a story based on date and title
        /// </summary>
        /// <param name="storyDate">date the story was published</param>
        /// <param name="urlTitle">url formatted title of the story</param>
        /// <returns></returns>
        public NewsBE GetStory(DateTime storyDate, string urlTitle)
        {
            var result = _entities.NewsSet
                .Where("it.date = CAST('" + storyDate + "' as System.DateTime)")
                .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                .Where("it.url_title like '" + urlTitle + "'")
                .OrderBy("it.date desc")
                .Take<NewsEntity>(1)
                .FirstOrDefault<NewsEntity>();

            return GetEntity(result);
        }

        /// <summary>
        /// Gets a list of news articles
        /// </summary>
        /// <param name="numStories">number of stories to return</param>
        /// <returns></returns>
        public List<NewsBE> NewsList(int numStories)
        {
            var news = new List<NewsEntity>(
                _entities.NewsSet
                  .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                  .OrderBy("it.date desc")
                  .Take(numStories)
                  .ToList());

            //GamesController gc = new GamesController();
            //news.AddRange(gc.GameListNewsList(gc.GameSummary(numStories)));

            //news.Sort((x, y) => DateTime.Compare(y.date, x.date));

            var result = new List<NewsBE>();
            foreach (NewsEntity newsE in news)
            {
                result.Add(GetEntity(newsE));
            }
            return result.GetRange(0, (news.Count < numStories) ? news.Count : numStories);
        }

        /// <summary>
        /// Gets a list of news articles for a certain year
        /// </summary>
        /// <param name="date">year from which to get news stories</param>
        /// <returns></returns>
        public List<NewsBE> NewsYear(DateTime date)
        {
            var news = new List<NewsEntity>
                (_entities.NewsSet
                  .Where("it.date BETWEEN CAST('" + date + "' as System.DateTime)" +
                        "AND CAST('" + date.AddYears(1) + "' as System.DateTime)")
                  .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                  .OrderBy("it.date desc")
                  .ToList());

            //GamesController gc = new GamesController();
            //news.AddRange(gc.GameListNewsList(gc.GameSummaryYear(date)));

            //news.Sort((x, y) => DateTime.Compare(y.date, x.date));

            var result = new List<NewsBE>();
            foreach (NewsEntity newsE in news)
            {
                result.Add(GetEntity(newsE));
            }
            return result;
        }

        /// <summary>
        /// Gets a list of news articles for a certain month from a certain year
        /// </summary>
        /// <param name="date">month and year from which to get news stories</param>
        /// <returns></returns>
        public List<NewsBE> NewsYearMonth(DateTime date)
        {
            var news = new List<NewsEntity>
                (_entities.NewsSet
                  .Where("it.date BETWEEN CAST('" + date + "' as System.DateTime)" +
                        "AND CAST('" + date.AddMonths(1) + "' as System.DateTime)")
                  .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                  .OrderBy("it.date desc")
                  .ToList());

            //GamesController gc = new GamesController();
            //news.AddRange(gc.GameListNewsList(gc.GameSummaryYearMonth(date)));

            //news.Sort((x, y) => DateTime.Compare(y.date, x.date));
            
            var result = new List<NewsBE>();
            foreach (NewsEntity newsE in news)
            {
                result.Add(GetEntity(newsE));
            }
            return result;
        }

        /// <summary>
        /// Gets a list of news articles for a certain complete date
        /// </summary>
        /// <param name="date">complete date from which to get news stories</param>
        /// <returns></returns>
        public List<NewsBE> NewsYearMonthDay(DateTime date)
        {
            var news = new List<NewsEntity>
                (_entities.NewsSet
                  .Where("it.date BETWEEN CAST('" + date + "' as System.DateTime)" +
                        "AND CAST('" + date.AddDays(1) + "' as System.DateTime)")
                  .Where("it.date <= CAST('" + DateTime.Now + "' as System.DateTime)")
                  .OrderBy("it.date desc")
                  .ToList());

            //GamesController gc = new GamesController();
            //news.AddRange(gc.GameListNewsList(gc.GameSummaryYearMonthDay(date)));

            //news.Sort((x, y) => DateTime.Compare(y.date, x.date));

            var result = new List<NewsBE>();
            foreach (NewsEntity newsE in news)
            {
                result.Add(GetEntity(newsE));
            }
            return result;
        }

        /// <summary>
        /// Converts a NewsEntity object to a NewsBE object
        /// </summary>
        /// <param name="news">NewsEntity to convert</param>
        /// <returns></returns>
        protected NewsBE GetEntity(NewsEntity news)
        {
            if (null == news)
            {
                return null;
            }

            var result = new NewsBE
            {
                Author = news.author,
                Date = news.date,
                Source = news.source,
                SourceUrl = news.source_url,
                Story = news.story,
                Title = news.title,
                TitlePath = news.url_title
            };
            return result;
        }
    }
}