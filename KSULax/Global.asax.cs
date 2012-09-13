using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KSULax.Models;

namespace KSULax
{
    public class KSU : System.Web.HttpApplication
    {
        /// <summary>
        /// The max season for which there are games.
        /// </summary>
        public static short maxGameSeason { get; private set; }

        /// <summary>
        /// The max season for which there are players.
        /// </summary>
        public static short maxPlayerSeason { get; private set; }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Games",
                "games/{id}",
                new { controller = "games", action = "Index", id = "" }
            );

            routes.MapRoute(
                "Players",
                "players/{id}",
                new { controller = "players", action = "Index", id = "" }
            );

            routes.MapRoute(
                "NationalRanking",
                "national-ranking/{id}",
                new { controller = "nationalranking", action = "national-ranking", id = "" },
                new { id = @"\d+" }
            );

            routes.MapRoute(
                "NationalRanking2",
                "national-ranking/{action}/{id}",
                new { controller = "nationalranking", action = "Index", id = "" }
            );

            routes.MapRoute(
                "News",
                "news/{year}/{month}/{day}/{url_title}",
                new { controller = "news", action = "Index", year = "", month = "", day = "", url_title = "" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = "" }
            );
        }

        protected void Application_Start()
        {
            KSU.maxGameSeason = 2013;
            KSU.maxPlayerSeason = 2012;

            RegisterRoutes(RouteTable.Routes);

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(EmailAttribute), typeof(EmailValidator));
        }
    }
}
