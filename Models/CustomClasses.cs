using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSULax.Models
{
    public class HomepageData
    {
        public List<Game> games { get; set; }
        public List<News> news { get; set; }
    }

    public class RosterData
    {
        public List<Game> games { get; set; }
        public List<PlayerSeason> players { get; set; }
    }

    public class Ranking
    {
        public short pollSource { get; set; }
        public DateTime date { get; set; }
        public string datestr { get; set; }
        public short rank { get; set; }
        public string rankUrl { get; set; }
    }
}
