using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;
using KSULax.Models;
using KSULax.Controllers;

namespace KSULax.Logic
{
    public class DataBL
    {
        KSULaxEntities _entities;

        public DataBL(KSULaxEntities entitity) { _entities = entitity; }

        /// <summary>
        /// Returns the most recent Top 25 Ranking for the team.
        /// </summary>
        /// <returns></returns>
        public List<TeamRankingBE> GetRanking()
        {
            List<TeamRankingBE> ranking = new List<TeamRankingBE>(3);
            ranking.Add(RecentRankingbyPollID(1));
            ranking[0].datestr = ranking[0].date.ToString("MMMM dd, yyyy");
            ranking.Add(RecentRankingbyPollID(2));
            ranking[1].datestr = ranking[1].date.ToString("MMMM dd, yyyy");
            ranking.Add(RecentRankingbyPollID(3));
            ranking[2].datestr = ranking[2].date.ToString("MMMM dd, yyyy");

            return ranking;
        }

        private TeamRankingBE RecentRankingbyPollID(int pollID)
        {
            var result = from Rank in _entities.PollSet.Where("it.pollsource_id = " + pollID).OrderBy("it.date desc").Take(1)
                         select new TeamRankingBE
                         {
                             pollSource = Rank.pollsource_id,
                             date = Rank.date,
                             rank = Rank.rank,
                             rankUrl = Rank.url
                         };

            return result.First<TeamRankingBE>();
        }
    }
}