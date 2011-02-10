using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;

namespace KSULax.Models.Game
{
    class GameStatModel
    {
        public GameStatModel(GameStatBE gamestat)
        {
            GameID = gamestat.GameID;
            SeasonID = gamestat.SeasonID;
            PlayerID = gamestat.PlayerID;
            Assists = gamestat.Assists;
            Goals = gamestat.Goals;
            Saves = gamestat.Saves;
            GoalsAgainst = gamestat.GoalsAgainst;
        }

        public int GameID { get; set; }
        public int SeasonID { get; set; }
        public int PlayerID { get; set; }
        public int Assists { get; set; }
        public int Goals { get; set; }
        public int Saves { get; set; }
        public int GoalsAgainst { get; set; }
    }
}
