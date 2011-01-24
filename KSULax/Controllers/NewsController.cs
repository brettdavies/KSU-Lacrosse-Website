using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Models;
using KSULax.Models.News;
using KSULax.Logic;
using KSULax.Entities;

namespace KSULax.Controllers
{
    [HandleError]
    public class NewsController : Controller
    {
        private KSULaxEntities _entities;
        private NewsBL _newsBL;

        public NewsController()
        {
            _entities = new KSULaxEntities();
            _newsBL = new NewsBL(_entities);
        }

        public ActionResult Index(int? year, int? month, int? day, string url_title)
        {
            //if everything is null or an empty string return all stories
            if (!year.HasValue && !month.HasValue && !day.HasValue && string.IsNullOrEmpty(url_title))
            {
                return View(new StoryListModel
                        {
                            Stories = GetStoryModels(_newsBL.NewsList(1000), this.Request.Url.ToString())
                        }
                    );
            }

            return Search(year, month, day, url_title);
        }

        public ActionResult Search(int? year, int? month, int? day, string url_title)
        {
            //if year exists
            if (year.HasValue)
            {
                //is year valid
                if (year.Value > DateTime.Now.Year)
                {
                    throw new Exception("KSULAX||the year " + year.Value + " is in the future.");
                }

                //if month exists
                if (month.HasValue)
                {
                    //is month valid
                    if (month.Value >= 1 && month.Value <= 12)
                    {
                        if (year.Value.Equals(DateTime.Now.Year) && month.Value > DateTime.Now.Month)
                        {
                            throw new Exception("KSULAX||" + new DateTime(year.Value, month.Value, 1).ToString("MMMM yyyy") + " is in the future.");
                        }

                        //if day exists
                        if (day.HasValue)
                        {
                            //is day valid
                            if (day.Value >= 1 && day.Value <= DateTime.DaysInMonth(year.Value, month.Value))
                            {
                                //if day is in the future
                                if (year.Value.Equals(DateTime.Now.Year) && month.Value.Equals(DateTime.Now.Month) && day.Value > DateTime.Now.Day)
                                {
                                    throw new Exception("KSULAX||" + new DateTime(year.Value, month.Value, day.Value).ToString("dd MMMM yyyy") + " is in the future.");
                                }

                                //if url_title is empty
                                if (string.IsNullOrEmpty(url_title))
                                {
                                    var stories = GetStoryModels(_newsBL.NewsYearMonthDay(new DateTime(year.Value, month.Value, day.Value)), this.Request.Url.ToString());

                                    if (stories.Count > 0)
                                    {
                                        var model = new StoryListModel
                                        {
                                            Stories = stories
                                        };

                                        return View("Search", model);
                                    }
                                    else
                                    {
                                        throw new Exception("KSULAX||we don't have any stories for " + new DateTime(year.Value, month.Value, day.Value).ToString("dd MMMM yyyy") + ".");
                                    }
                                }

                                return Story(year.Value, month.Value, day.Value, url_title);
                            }
                            else
                            {
                                throw new Exception("KSULAX||" + year.GetValueOrDefault() + "/" +
                                   month.GetValueOrDefault() + "/" +
                                   day.GetValueOrDefault() + " is not a valid date.");
                            }
                        }
                        else
                        {
                            var stories = GetStoryModels(_newsBL.NewsYearMonth(new DateTime(year.Value, month.Value, 1)), this.Request.Url.ToString());

                            if (stories.Count > 0)
                            {
                                var model = new StoryListModel
                                {
                                    Stories = stories
                                };

                                return View("Search", model);
                            }
                            else
                            {
                                throw new Exception("KSULAX||we don't have any stories for " + new DateTime(year.Value, month.Value, 1).ToString("MMMM yyyy") + ".");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("KSULAX||" + year.GetValueOrDefault() + "/" +
                                  month.GetValueOrDefault() + "/" +
                                  day.GetValueOrDefault() + " is not a valid date.");
                    }
                }
                else
                {
                    var stories = GetStoryModels(_newsBL.NewsYear(new DateTime(year.Value, 1, 1)), this.Request.Url.ToString());

                    if (stories.Count > 0)
                    {
                        var model = new StoryListModel
                        {
                            Stories = stories
                        };

                        return View("Search", model);
                    }
                    else
                    {
                        throw new Exception("KSULAX||we don't have any stories for the year " + year.Value + ".");
                    }
                }
            }
            else
            {
                throw new Exception("KSULAX||" + year.GetValueOrDefault() + "/" +
                    month.GetValueOrDefault() + "/" +
                    day.GetValueOrDefault() + " is not a valid date.");
            }
        }

        public ActionResult Story(int year, int month, int day, string url_title)
        {
            DateTime storyDate;

            if (!DateTime.TryParse(year.ToString() + "/" + month.ToString() + "/" + day.ToString(), out storyDate))
            {
                throw new Exception("KSULAX||" + year + "/" +
                   month+ "/" +
                   day + " is not a valid date.");
            }

            var story = _newsBL.GetStory(storyDate, url_title);

            if (null == story)
            {
                throw new Exception("KSULAX||we can't find the the story you requested");
            }

            return View("Story", new StoryModel(story, this.Request.Url.ToString()));
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
