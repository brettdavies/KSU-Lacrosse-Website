using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Models;
using KSULax.Logic;
using KSULax.Entities;

namespace KSULax.Controllers
{
    [HandleError]
    public class MediaController : Controller
    {
        KSULaxEntities _entities;
        MediaBL _mediaBL;

        public MediaController()
        {
            _entities = new KSULaxEntities();
            _mediaBL = new MediaBL(_entities);
        }

        public ActionResult Index() { return null; }

        public List<PhotoGalleryBE> PhotoGalleriesBySeason(int season_id)
        {
            return _mediaBL.PhotoGalleriesBySeason(season_id);
        }
    }
}
