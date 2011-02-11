using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using KSULax.Entities;
using KSULax.Models.Game;
using KSULax.Models.News;

namespace KSULax.Models.Home
{
    public class HomepageDataModel
    {
        public GameListModel games { get; set; }
        public StoryBriefListModel Stories { get; set; }
    }
}
