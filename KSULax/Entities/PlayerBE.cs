using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSULax.Entities
{
    public class PlayerBE
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Hometown { get; set; }
        public string HomeState { get; set; }
        public string HighSchool { get; set; }
        public string Major { get; set; }
        public string Bio { get; set; }
        public List<PlayerSeasonBE> PlayerSeason { get; set; }
        public List<PlayerGameBE> PlayerGame { get; set; }
        public List<PlayerAwardBE> PlayerAward { get; set; }
    }

    public class PlayerSeasonBE
    {
        public int PlayerID { get; set; }
        public int SeasonID { get; set; }
        public int JerseyNum { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string ClassYr { get; set; }
        public string EligibilityYr { get; set; }
        
        /// <summary>
        /// True if the player is club president that season.
        /// </summary>
        public bool President { get; set; }

        /// <summary>
        /// True if the player is a club officer that season.
        /// </summary>
        public bool Officer { get; set; }

        /// <summary>
        /// True if the player is a team captain that season.
        /// </summary>
        public bool Captain { get; set; }
        public PlayerBE Player { get; set; }
    }

    public class PlayerGameBE
    {
        public int GameID { get; set; }
        public int PlayerID { get; set; }
        public int Assists { get; set; }
        public int Goals { get; set; }
        public int Saves { get; set; }
        public int GoalsAgainst { get; set; }
        public GameBE Game { get; set; }
        public PlayerBE Player { get; set; }
    }

    public class PlayerAwardBE
    {
        public int PlayerID { get; set; }
        public int AwardID { get; set; }
        public DateTime Date { get; set; }
        public AwardBE Award { get; set; }
        public PlayerBE Player { get; set; }
    }

    public class AwardBE
    {
        public int AwardID { get; set; }
        public string Name { get; set; }
        public List<PlayerAwardBE> PlayerAward { get; set; }
    }
}