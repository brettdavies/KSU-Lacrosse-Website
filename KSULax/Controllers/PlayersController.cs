using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using KSULax.Models;
using KSULax.Logic;
using KSULax.Entities;
using KSULax.Models.Player;

namespace KSULax.Controllers
{
    [HandleError]
    public class PlayersController : Controller
    {
        private KSULaxEntities _entities;
        private PlayerBL _playerBL;

        public PlayersController()
        {
            _entities = new KSULaxEntities();
            _playerBL = new PlayerBL(_entities);
        }

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
                    RosterDataModel data = new RosterDataModel();

                    data.games = gc.GamesList(player_id);
                    data.players = _playerBL.PlayersBySeason(player_id);

                    if (data.players.Count.Equals(0))
                    {
                        throw new Exception("KSULAX||we can't find the roster you requested");
                    }

                    else
                    {
                        return View(data);
                    }
                }

                //find player by id
                else
                {
                    string name = string.Empty;
                    if (_playerBL.getPlayerNamebyID(player_id, out name))
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
                    PlayerBE result = new PlayerBE();

                    if (_playerBL.PlayerByName(id, out result))
                    {
                        return View("Story", result);
                    }
                    else
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
    }
}
