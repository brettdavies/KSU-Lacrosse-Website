using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSULax.Models.Game;
using KSULax.Entities;

namespace KSULax.Models.Player
{
    public class PlayerGameStatListModel
    {
        public List<PlayerGameTotalModel> GameStat { get; set; }

        public bool isCurPlayer { get; set; }

        public PlayerGameStatListModel(List<GameStatBE> gameStatBELst)
        {
            SortedDictionary<int, PlayerGameTotalModel> seasonTotals = GameStatCalculateTotals(gameStatBELst);

            isCurPlayer = (seasonTotals.Keys.Contains<int>(KSU.maxGameSeason)) ? true : false;

            GameStat = seasonTotals.Values.ToList();
        }

        public int CareerGames
        {
            get
            {
                int total = 0;

                foreach (PlayerGameTotalModel pstm in GameStat)
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

                foreach (PlayerGameTotalModel pstm in GameStat)
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

                foreach (PlayerGameTotalModel pstm in GameStat)
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

                foreach (PlayerGameTotalModel pstm in GameStat)
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

                foreach (PlayerGameTotalModel pstm in GameStat)
                {
                    total += pstm.GoalsAgainst;
                }

                return total;
            }
        }

        public int CareerPoints
        {
            get
            {
                return CareerGoals + CareerAssists;
            }
        }

        public double CareerGoalsPerGame
        {
            get
            {
                return CareerGames.Equals(0) ? 0 : Math.Round(((double)CareerGoals / (double)CareerGames), 2);
            }
        }

        public double CareerAssistsPerGame
        {
            get
            {
                return CareerGames.Equals(0) ? 0 : Math.Round(((double)CareerAssists / (double)CareerGames), 2);
            }
        }

        public double CareerPointsPerGame
        {
            get
            {
                return CareerGames.Equals(0) ? 0 : Math.Round(((double)CareerPoints / (double)CareerGames), 2);
            }
        }

        private SortedDictionary<int, PlayerGameTotalModel> GameStatCalculateTotals(List<GameStatBE> gameStatBELst)
        {
            var pgtm = new SortedDictionary<int,PlayerGameTotalModel>();

            foreach (GameStatBE gs in gameStatBELst)
            {
                int seasonID = gs.SeasonID;
                if (pgtm.ContainsKey(seasonID))
                {
                    pgtm[seasonID].Assists += gs.Assists;
                    pgtm[seasonID].GamesPlayed++;
                    pgtm[seasonID].Goals += gs.Goals;
                    pgtm[seasonID].GoalsAgainst += gs.GoalsAgainst;
                    pgtm[seasonID].Saves += gs.Saves;
                }

                else
                {
                    pgtm.Add(seasonID, new PlayerGameTotalModel
                    {
                        Assists = gs.Assists,
                        GamesPlayed = 1,
                        Goals = gs.Goals,
                        GoalsAgainst = gs.GoalsAgainst,
                        Saves = gs.Saves,
                        SeasonID = gs.SeasonID
                    });
                }
            }

            return pgtm;
        }
    }

    public class PlayerGameTotalModel
    {
        public int SeasonID { get; set; }
        public int GamesPlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Saves { get; set; }
        public int GoalsAgainst { get; set; }

        public int Points
        {
            get
            {
                return Goals + Assists;
            }
        }

        public double GoalsPerGame
        {
            get
            {
                return GamesPlayed.Equals(0) ? 0 : Math.Round(((double)Goals / (double)GamesPlayed), 2);
            }
        }

        public double AssistsPerGame
        {
            get
            {
                return GamesPlayed.Equals(0) ? 0 : Math.Round(((double)Assists / (double)GamesPlayed), 2);
            }
        }

        public double PointsPerGame
        {
            get
            {
                return GamesPlayed.Equals(0) ? 0 : Math.Round(((double)Points / (double)GamesPlayed), 2);
            }
        }
    }
}