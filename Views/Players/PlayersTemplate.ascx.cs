using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace KSULax
{
    public partial class PlayersTemplate : ViewUserControl<KSULax.Models.PlayerSeasonEntity>
    {
        public void page_load(object sender, EventArgs e) {}

        /// <summary>
        /// Formats a players height (X"Y') based on their height in inches
        /// </summary>
        /// <param name="totalInches">Height of the player expressed in inches</param>
        /// <returns>A properly formatted (X"Y') string expressing the player's height</returns>
        public string formatHeight(int totalInches)
        {
            int feet, inches;
            feet = totalInches / 12;
            inches = totalInches - (feet * 12);
            return feet+"&#39;"+inches+"&quot;";
        }

        /// <summary>
        /// Returns the state of a players highschool when it is not Georgia
        /// </summary>
        /// <param name="homestate">Two letter abbrevation of the state</param>
        /// <returns>If the state is not Georgia then a string containing the players highschool state is returned. If the state is Georgia then an empty string is returned</returns>
        public string state(string homestate)
        {
            if (!string.IsNullOrEmpty(homestate) && !homestate.ToUpper().Equals("GA"))
            { return " ("+homestate.ToUpper()+")"; }
            else { return string.Empty; }
        }
    }
}
