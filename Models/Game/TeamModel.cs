using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSULax.Entities;

namespace KSULax.Models.Game
{
    public class TeamModel
    {
        public TeamModel() { }

        public TeamModel(TeamBE team)
        {
            ID = team.ID;
            Name = team.Name;
            Abr = team.Abr;
            Slug = team.Slug;
            TeamURL = team.TeamURL;
            Mascot = team.Mascot;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Abr { get; set; }
        public string Slug { get; set; }
        public string TeamURL { get; set; }
        public string Mascot { get; set; }

        public TeamModel GetModel(TeamBE teamBE)
        {
            if (null == teamBE)
            {
                return null;
            }

            var result = new TeamModel()
            {
               Abr = teamBE.Abr,
               ID = teamBE.ID,
               Mascot = teamBE.Mascot,
               Name = teamBE.Name,
               Slug = teamBE.Slug,
               TeamURL = teamBE.TeamURL
            };
            return result;
        }
    }
}
