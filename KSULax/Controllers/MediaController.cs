using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Models;

namespace KSULax.Controllers
{
    [HandleError]
    public class MediaController : Controller
    {
        KSULaxEntities entities;

        public MediaController() { entities = new KSULaxEntities(); }

        public ActionResult Index()
        { return View(); }

        public List<PhotoGallery> PhotoGallery(int season_id)
        {
            return (entities.PhotoGallerySet
                      .Include("Photographers")
                      .Include("Games")
                      .Where("it.Games.game_season_id = " + season_id)
                      .OrderBy("it.Games.game_date")
                      .OrderBy("it.url")
                      .ToList());
        }
    }
}
