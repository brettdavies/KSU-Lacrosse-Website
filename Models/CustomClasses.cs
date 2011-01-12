using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KSULax.Models
{
    public class HomepageData
    {
        public List<Game> games { get; set; }
        public List<News> news { get; set; }
    }

    public class RosterData
    {
        public List<Game> games { get; set; }
        public List<PlayerSeason> players { get; set; }
    }

    public class Ranking
    {
        public short pollSource { get; set; }
        public DateTime date { get; set; }
        public string datestr { get; set; }
        public short rank { get; set; }
        public string rankUrl { get; set; }
    }


    #region Database Model Validations

    [MetadataType(typeof(Photographer_Validation))]
    public partial class Photographer { }

    [Bind(Exclude = "photographer_id")]
    public class Photographer_Validation
    {
        [Required(ErrorMessage = "Required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string company { get; set; }

        [Required(ErrorMessage = "Required")]
        public string url { get; set; }
    }

    #endregion Database Model Validations
}
