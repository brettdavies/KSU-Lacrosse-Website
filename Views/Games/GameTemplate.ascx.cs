using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace KSULax
{
    public partial class GameTemplate : ViewUserControl<KSULax.Models.GameEntity>
    {
        public void page_load(object sender, EventArgs e) { }

        /// <summary>
        /// Returns the outcome of the game
        /// </summary>
        /// <param name="home_team_score">The home team's score or null</param>
        /// <param name="away_team_score">The away team's score or null</param>
        /// <param name="home">If KSU is the home team</param>
        /// <returns>A String representing the outcome of the game</returns>
        public string gameResult(int? home_team_score, int? away_team_score, bool home)
        {
            if (!home_team_score.HasValue || !away_team_score.HasValue)
            { return "-"; }
            else if (home && (home_team_score > away_team_score))
            { return "W " + home_team_score + " - " + away_team_score; }
            else if (!home && (away_team_score > home_team_score))
            { return "W " + away_team_score + " - " + home_team_score; }
            else if (!home)
            { return "L " + away_team_score + " - " + home_team_score; }
            else if (home)
            { return "L " + home_team_score + " - " + away_team_score; }
            else { return string.Empty; }
        }
    }
}
