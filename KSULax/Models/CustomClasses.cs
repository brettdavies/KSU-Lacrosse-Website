using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using KSULax.Entities;
using KSULax.Models.News;

namespace KSULax.Models
{
    public class HomepageDataModel
    {
        public List<GameEntity> games { get; set; }
        public List<StoryModel> Stories { get; set; }
    }

    public class RosterDataModel
    {
        public List<GameEntity> games { get; set; }
        public List<PlayerSeasonBE> players { get; set; }
    }
}
