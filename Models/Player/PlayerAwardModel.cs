using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSULax.Entities;

namespace KSULax.Models.Player
{
    public class PlayerAwardModelList
    {
        public PlayerAwardModelList(List<AwardBE> awardBElst)
        {
            playerAwards = new List<PlayerAwardModel>();

            awardBElst.Sort((a,b) => DateTime.Compare(b.Date, a.Date));

            foreach (AwardBE awardBE in awardBElst)
            {
                playerAwards.Add(new PlayerAwardModel(awardBE));
            }
        }

        public List<PlayerAwardModel> playerAwards;

        /// <summary>
        /// Returns if the player has any awards or not.
        /// </summary>
        public bool PlayerHasAwards
        {
            get
            {
                if (playerAwards.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    public class PlayerAwardModel
    {
        public PlayerAwardModel(AwardBE award)
        {
            AwardID = award.AwardID;
            Name = award.Name;
            Date = award.Date;
        }

        public int AwardID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public string formatDate
        {
            get
            {
                return Date.ToString(("MMM dd"));
            }
        }

        public bool isWeeklyAward
        {
            get
            {
                return AwardID.Equals(29);
            }
        }
    }
}
