using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;

namespace KSULax.Models.Player
{
    public class PlayerModel
    {
        public PlayerModel(PlayerBE player)
        {
            PlayerID = player.PlayerID;
            FirstName = player.FirstName;
            MiddleName = player.MiddleName;
            LastName = player.LastName;
            Hometown = player.Hometown;
            HomeState = player.HomeState;
            HighSchool = player.HighSchool;
            Major = player.Major;
            Bio = player.Bio;

            //Sort PlayerSeason in Descending Order by Season ID
            PlayerSeason = player.PlayerSeason;
            if (PlayerSeason.Count > 0)
            {
                PlayerSeason.Sort((x, y) => string.Compare(y.SeasonID.ToString(), x.SeasonID.ToString()));
            }

            //Sort PlayerGame in Descending Order by Game Date
            PlayerGame = player.PlayerGame;
            if (PlayerGame.Count > 0)
            {
                PlayerGame.Sort((x, y) => DateTime.Compare(y.Game.Date, x.Game.Date));
            }

            //Sort PlayerAward in Descending Order by Award Date
            PlayerAward = player.PlayerAward;
            if (PlayerAward.Count > 0)
            {
                PlayerAward.Sort((x, y) => DateTime.Compare(y.Date, x.Date));
            }

            //Calculate Stat Totals
            PlayerGameTotal = CalcPlayerGameTotal();
        }

        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Hometown { get; set; }
        public string HomeState { get; set; }
        public string HighSchool { get; set; }
        public string Major { get; set; }
        public string Bio { get; set; }
        
        /// <summary>
        /// Ordered in descending order by SeasonID.
        /// </summary>
        public List<PlayerSeasonBE> PlayerSeason { get; set; }

        public List<PlayerGameBE> PlayerGame { get; set; }

        /// <summary>
        /// Ordered in descending order by Award Date.
        /// </summary>
        public List<PlayerAwardBE> PlayerAward { get; set; }

        /// <summary>
        /// List containing the season totals for the players stats
        /// </summary>
        public List<PlayerGameTotalModel> PlayerGameTotal { get; set; }

        /// <summary>
        /// Returns the players Hometown and HomeState.
        /// </summary>
        public string Home
        {
            get
            {
                return (Hometown + ", " + HomeState);
            }
        }

        /// <summary>
        /// Returns the plaers FullName.
        /// </summary>
        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName);
            }
        }

        /// <summary>
        /// Returns a URL friendly version of the player's FullName.
        /// </summary>
        public string FullNameURL
        {
            get
            {
                return (FullName.Replace(" ","-")).ToLower();
            }
        }

        public string ImagePath()
        {
            string imagePath = "/content/images/players/" + PlayerID + ".png";
            //if (! System.IO.File.Exists(MapPath(imagePath)))
            //{
            //    imagePath = "/content/images/teams/kennesaw_state_128.png";
            //}
            return imagePath;
        }

        /// <summary>
        /// Returns the most recent season for the player
        /// </summary>
        public PlayerSeasonBE? RecentSeason
        {
            get
            {
                if (null != PlayerSeason[0])
                {
                    return PlayerSeason[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns the players height (X"Y') based on their height in inches from their most recent season.
        /// </summary>
        public string HeightFeet
        {
            get
            {
                return ((RecentSeason.GetValueOrDefault().Height / 12) + "&#39;" + (RecentSeason.GetValueOrDefault().Height - (RecentSeason.GetValueOrDefault().Height / 12 * 12)) + "&quot;");
            }
        }

        /// <summary>
        /// Returns True if the player is a current player and False otherwise.
        /// </summary>
        public bool isCurPlayer
        {
            get
            {
                if (short.Equals(RecentSeason.GetValueOrDefault(), KSU.maxPlayerSeason))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns the most recent jersey number for the player.
        /// </summary>
        public int RecentJerseyNum
        {
            get
            {
                return RecentSeason.GetValueOrDefault().JerseyNum;
            }
        }

        public int CareerGames
        {
            get
            {
                int total = 0;

                foreach (PlayerGameTotalModel pstm in PlayerGameTotal)
                {
                    total += pstm.GamesPlayed;
                }

                return total;
            }
        }

        public int CareerGoals
        {
            get
            {
                int total = 0;

                foreach (PlayerGameTotalModel pstm in PlayerGameTotal)
                {
                    total += pstm.Goals;
                }

                return total;
            }
        }

        public int CareerAssists
        {
            get
            {
                int total = 0;

                foreach (PlayerGameTotalModel pstm in PlayerGameTotal)
                {
                    total += pstm.Assists;
                }

                return total;
            }
        }

        public int CareerSaves
        {
            get
            {
                int total = 0;

                foreach (PlayerGameTotalModel pstm in PlayerGameTotal)
                {
                    total += pstm.Saves;
                }

                return total;
            }
        }

        public int CareerGoalsAgainst
        {
            get
            {
                int total = 0;

                foreach (PlayerGameTotalModel pstm in PlayerGameTotal)
                {
                    total += pstm.GoalsAgainst;
                }

                return total;
            }
        }

        /// <summary>
        /// Returns if the player has any awards or not.
        /// </summary>
        public bool PlayerHasAwards
        {
            get
            {
                if (PlayerAward.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Calculates the stat totals for each season a player played. Only counts games that are not scrimages and have a "0" status.
        /// </summary>
        /// <returns>A list containing stat totals for each season a player played.</returns>
        private List<PlayerGameTotalModel> CalcPlayerGameTotal()
        {
            var pgtm = new List<PlayerGameTotalModel>();

            foreach (PlayerGameBE pg in PlayerGame)
            {
                bool statusValid = (pg.Game.Status.Equals("0") ? true : false);
                bool typeValid = (!pg.Game.Type.Equals("scrimage") ? true : false);

                if (statusValid && typeValid)
                {
                    int index = pgtm.FindIndex(s => s.SeasonID == pg.Game.SeasonID);

                    if (index < 0)
                    {
                        PlayerSeasonBE ps = pg.Player.PlayerSeason.Find(s => s.SeasonID == pg.Game.SeasonID);
                        
                        pgtm.Add(new PlayerGameTotalModel
                        {
                            Assists = pg.Assists,
                            ClassYr = ps.EligibilityYr,
                            GamesPlayed = 1,
                            Goals = pg.Goals,
                            GoalsAgainst = pg.GoalsAgainst,
                            Saves = pg.Saves,
                            SeasonID = pg.Game.SeasonID
                        });
                    }
                    else
                    {
                        pgtm[index].Assists += pg.Assists;
                        pgtm[index].GamesPlayed++;
                        pgtm[index].Goals += pg.Goals;
                        pgtm[index].GoalsAgainst += pg.GoalsAgainst;
                        pgtm[index].Saves += pg.Saves;
                    }
                }
            }

            return pgtm;
        }
    }

    public class PlayerGameTotalModel
    {
        public int SeasonID { get; set; }
        public string ClassYr { get; set; }
        public int GamesPlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Saves { get; set; }
        public int GoalsAgainst { get; set; }
    }
}