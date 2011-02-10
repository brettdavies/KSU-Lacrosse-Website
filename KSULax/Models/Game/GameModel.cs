using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSULax.Entities;

namespace KSULax.Models.Game
{
    public class GameListModel
    {
        public GameListModel(List<GameBE> gameBElst)
        {
            Games = new List<GameModel>();

            foreach (GameBE gameBE in gameBElst)
            {
                Games.Add(new GameModel(gameBE));
            }
        }

        public List<GameModel> Games { get; set; }

        public int Season
        {
            get
            {
                return Games[0].SeasonID;
            }
        }
    }

    public class GameModel
    {
        public GameModel() { }

        public GameModel(GameBE game)
        {
            ID = game.ID;
            SeasonID = game.SeasonID;
            Date = game.Date;
            Time = game.Time;
            Type = game.Type;
            Status = game.Status;
            Venue = game.Venue;
            Detail = game.Detail.Replace("<br>", "<br/>");
            AwayTeamScore = game.AwayTeamScore;
            HomeTeamScore = game.HomeTeamScore;
            AwayTeam = new TeamModel(game.AwayTeam);
            HomeTeam = new TeamModel(game.HomeTeam);
            isHome = game.isHome;
        }
       
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
        public TeamModel HomeTeam { get; set; }
        public TeamModel AwayTeam { get; set; }
        public bool isHome { get; set; }

        public string HomeOrAway
        {
            get
            {
                return (isHome ? "home" : "away");
            }
        }

        public TeamModel KSU
        {
            get
            {
                return (isHome ? HomeTeam : AwayTeam);
            }
        }

        public TeamModel Opponent
        {
            get
            {
                return (isHome ? AwayTeam : HomeTeam);
            }
        }

        public string FallOrSpring
        {
            get
            {
                return ((SeasonID > Date.Year) ? "fall" : "spring");
            }
        }

        public string DateShort
        {
            get
            {
                return Date.ToString("M / d");
            }
        }

        public string DateDay
        {
            get
            {
                return Date.ToString("ddd");
            }
        }

        public string DateSchedule
        {
            get
            {
                return Date.ToString("MMM dd");
            }
        }

        public string TimeSchedule
        {
            get
            {
                return Date.ToString("hh:mm tt");
            }
        }

        public bool StatusNormal
        {
            get
            {
                return (Status.Equals("0") ? true : false);
            }
        }

        public bool hasDetail
        {
            get
            {
                return !string.IsNullOrEmpty(Detail);
            }
        }

        public bool isWin
        {
            get
            {
                if (isHome)
                {
                    return (HomeTeamScore > AwayTeamScore) ? true : false;
                }

                else
                {
                    return (HomeTeamScore < AwayTeamScore) ? true : false;
                }
            }
        }

        public bool isMCLAGame
        {
            get
            {
                return (ID > 6000 && HomeTeamScore >= 0) ? true : false;
            }
        }

        public string GameResultBL
        {
            get
            {
                if (HomeTeamScore.Equals(-1) || AwayTeamScore.Equals(-1))
                {
                    return "-";
                }

                else if (isHome && (HomeTeamScore > AwayTeamScore))
                {
                    return "beats";
                }

                else if (!isHome && (AwayTeamScore > HomeTeamScore))
                {
                    return "beats";
                }

                else if (!isHome)
                {
                    return "loses to";
                }

                else if (isHome)
                {
                    return "loses to";
                }

                else
                {
                    return string.Empty;
                }
            }
        }

        public string GameResultWL
        {
            get
            {
                if (HomeTeamScore.Equals(-1) || AwayTeamScore.Equals(-1))
                {
                    return "-";
                }

                else if (isHome && (HomeTeamScore > AwayTeamScore))
                {
                    return "W " + HomeTeamScore + " - " + AwayTeamScore;
                }

                else if (!isHome && (AwayTeamScore > HomeTeamScore))
                {
                    return "W " + AwayTeamScore + " - " + HomeTeamScore;
                }

                else if (!isHome)
                {
                    return "L " + AwayTeamScore + " - " + HomeTeamScore;
                }

                else if (isHome)
                {
                    return "L " + HomeTeamScore + " - " + AwayTeamScore;
                }

                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
