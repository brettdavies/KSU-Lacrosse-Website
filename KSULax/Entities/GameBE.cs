using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSULax.Entities
{
    class GameBE
    {
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
        public TeamBE AwayTeam { get; set; }
        public TeamBE HomeTeam { get; set; }
        public List<PhotoGalleryBE> PhotoGallery { get; set; }
        public List<PhotoBE> Photo { get; set; }
        public List<PlayerGameBE> PlayerGame { get; set; }
    }
}
