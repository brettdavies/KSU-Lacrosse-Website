using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSULax.Models;
using KSULax.Logic;
using KSULax.Entities;
using KSULax.Dal;

namespace KSULax.Controllers
{
    public class DataController : Controller
    {
        private KSULaxEntities _entities;
        private DataBL _dataBL;

        public DataController()
        {
            _entities = new KSULaxEntities();
            _dataBL = new DataBL(_entities);
        }

        public ActionResult Index()
        {
            return null;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetRanking()
        {
            return this.Json(_dataBL.GetRanking(), JsonRequestBehavior.AllowGet);
        }
    }
}
