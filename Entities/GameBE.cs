using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSULax.Entities
{
    /// <summary>
    /// Holds information related to a game.
    /// </summary>
    public class GameBE
    {
        public int ID { get; set; }
        public int SeasonID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Venue { get; set; }
        public string Detail { get; set; }
        public int AwayTeamScore { get; set; }
        public int HomeTeamScore { get; set; }
        public TeamBE HomeTeam { get; set; }
        public TeamBE AwayTeam { get; set; }
        public bool isHome { get; set; }
    }

    /// <summary>
    /// Holds stats from a game.
    /// </summary>
    public class GameStatBE
    {
        public int GameID { get; set; }
        public int SeasonID { get; set; }
        public int PlayerID { get; set; }
        public int Assists { get; set; }
        public int Goals { get; set; }
        public int Saves { get; set; }
        public int GoalsAgainst { get; set; }
    }
}
