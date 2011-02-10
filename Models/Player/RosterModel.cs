using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Models;
using KSULax.Logic;
using KSULax.Models.Game;

namespace KSULax.Models.Player
{
    public class RosterModel
    {
        public RosterModel()
        {
            Games = null;
            Players = null;
        }

        public RosterModel(GameListModel GameList, List<PlayerModel> PlayerModelLst)
        {
            Games = GameList;
            Players = PlayerModelLst;
        }

        public GameListModel Games { get; set; }
        public List<PlayerModel> Players { get; set; }

        /// <summary>
        /// The current season as an int.
        /// </summary>
        public int CurSeason
        {
            get
            {
                return Players[0].SeasonID;
            }
        }

        /// <summary>
        /// The current season as a string.
        /// </summary>
        public string CurSeasonStr
        {
            get
            {
                return CurSeason.ToString();
            }
        }

        /// <summary>
        /// Returns the following string: (CurSeason - 1) + " - " + CurSeason + " Roster".
        /// </summary>
        public string Title
        {
            get
            {
                return (CurSeason - 1) + " - " + CurSeason + " Roster"; 
            }
        }
    }
}