using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;
using KSULax.Interfaces;

namespace KSULax.Models.News
{
    public class StoryBriefListModel
    {
        public StoryBriefListModel (List<INews> news, string requestUrl)
        {
            Stories = new List<StoryBriefModel>();

            foreach (var story in news)
            {
                Stories.Add(new StoryBriefModel(story, requestUrl));
            }
        }

        public List<StoryBriefModel> Stories { get; set; }
    }

    public class StoryBriefModel
    {
        public StoryBriefModel(INews news, string requestUrl)
        {
            if (null != news)
            {
                Date = news.Date;
                Story = news.Story;
                Title = news.Title;
                TitlePath = news.TitlePath;
                SeasonID = news.SeasonID;
                GameID = news.GameID;
                StoryType = news.getType();
            }
        }

        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string TitlePath { get; set; }
        public string Story { get; set; }
        public int SeasonID { get; set; }
        public int GameID { get; set; }
        public NewsType StoryType { get; set; }
    }
}