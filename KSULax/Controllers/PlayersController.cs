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
    public class PlayersController : Controller
    {
        KSULaxEntities entities;

        public PlayersController() { entities = new KSULaxEntities(); }

        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "players", new { id = KSU.maxPlayerSeason });
            }

            short player_id;
            if (short.TryParse(id, out player_id))
            {
                if (player_id >= 2010 && player_id <= KSU.maxPlayerSeason)
                {
                    GamesController gc = new GamesController();
                    RosterData data = new RosterData();

                    data.games = gc.GamesList(player_id);
                    data.players = PlayersList(player_id);

                    if (data.players.Count.Equals(0))
                    {
                        throw new Exception("KSULAX||we can't find the roster you requested");
                    }

                    else
                    {
                        ViewData.Model = data;
                        return View();
                    }
                }

                //find player by id
                else
                {
                    string name = string.Empty;
                    if (getPlayerNamebyID(player_id, out name))
                    {
                        return RedirectToAction("Index", "players", new { id = name });
                    }

                    else
                    {
                        throw new Exception("KSULAX||we can't find the player id you requested");
                    }
                }
            }

            //find player by full name
            else
            {
                if (string.Compare(id, id.ToLower()).Equals(0))
                {
                    string first = string.Empty;
                    string last = string.Empty;

                    try
                    {
                        first = id.Substring(0, id.IndexOf("-"));
                        last = id.Substring(id.IndexOf("-") + 1);

                        List<Player> result = entities.PlayerSet
                             .Include("PlayerGame")
                             .Include("PlayerSeason")
                             .Include("PlayerAward")
                             .Include("PlayerAward.Award")
                             .Where("it.first like ('" + first + "')")
                             .Where("it.last like ('" + last + "')")
                             .Take(1)
                             .ToList();

                        if (result.Count > 0)
                        {
                            ViewData.Model = result.ElementAt<Player>(0);
                            return View("Player");
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception("KSULAX||we can't find the player you requested");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "players", new { id = id.ToLower() });
                }
            }
        }

        private bool getPlayerNamebyID(short player_id, out string name)
        {
            List<Player> result = entities.PlayerSet
                      .Where("it.id = " + player_id)
                      .Take(1)
                      .ToList();

            if (result.Count() > 0)
            {
                name = (result.ElementAt<Player>(0).first + "-" + result.ElementAt<Player>(0).last).ToLower();
                return true;
            }
            else
            {
                name = string.Empty;
                return false;
            }
        }

        public List<PlayerSeason> PlayersList(int id)
        {
            return (entities.PlayerSeasonSet
                      .Include("Player")
                      .Where("it.season_id = " + id)
                      .OrderBy("it.jersey")
                      .ToList());
        }
    }
}
