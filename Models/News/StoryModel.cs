using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;

namespace KSULax.Models.News
{
    public class StoryListModel
    {
        public StoryListModel (List<NewsBE> news, string requestUrl)
        {
            Stories = new List<StoryModel>();

            foreach (var story in news)
            {
                Stories.Add(new StoryModel(story, requestUrl));
            }
        }

        public List<StoryModel> Stories { get; set; }
    }

    public class StoryModel
    {
        public StoryModel(NewsBE news, string requestUrl)
        {
            Author = news.Author;
            Date = news.Date;
            Source = news.Source;

            if (String.IsNullOrEmpty(news.SourceUrl))
            {
                SourceUrl = requestUrl;
            }
            else
            {
                SourceUrl = news.SourceUrl;
            }
            
            Story = news.Story.Trim();
            Title = news.Title.Trim();
            TitlePath = news.TitlePath;
        }

        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string TitlePath { get; set; }
        public string Story { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
        public string SourceUrl { get; set; }
        public bool HasExternalSource
        {
            get
            {
                return (!String.IsNullOrEmpty(Source) && !String.IsNullOrEmpty(SourceUrl));
            }
        }
        public bool HasAuthor
        {
            get
            {
                return (!String.IsNullOrEmpty(Author));
            }
        }
    }
}