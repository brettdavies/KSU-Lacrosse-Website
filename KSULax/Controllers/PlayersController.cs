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
using KSULax.Models.Game;
using KSULax.Dal;

namespace KSULax.Controllers
{
    [HandleError]
    public class PlayersController : Controller
    {
        private KSULaxEntities _entities;
        private PlayerBL _playerBL;
        private GameBL _gameBL;
        private AwardBL _awardBL;

        public PlayersController()
        {
            _entities = new KSULaxEntities();
            _playerBL = new PlayerBL(_entities);
            _gameBL = new GameBL(_entities);
            _awardBL = new AwardBL(_entities);
        }

        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "roster", new { id = KSU.maxPlayerSeason });
                //return RedirectToAction("Index", "players", new { id = KSU.maxPlayerSeason });
            }

            int player_id;
            if (int.TryParse(id, out player_id))
            {
                return RedirectToAction("Index", "roster", new { id = player_id });

                //if (player_id >= 2010 && player_id <= KSU.maxPlayerSeason)
                //{
                //    RosterModel data = new RosterModel();

                //    data.Players = GetPlayerModelLst(_playerBL.PlayersBySeason(player_id));
                //    data.Games = new GameListModel(_gameBL.GamesBySeason(player_id));

                //    if (data.Players.Count.Equals(0) && player_id.Equals(KSU.maxGameSeason))
                //    {
                //        throw new Exception("KSULAX||Player profiles for " + player_id + " coming soon!");
                //    }
                //    else if (data.Players.Count.Equals(0))
                //    {
                //        throw new Exception("KSULAX||we can't find the roster you requested");
                //    }
                //    else
                //    {
                //        return View(data);
                //    }
                //}

                ////find player by id
                //else
                //{
                //    string name = string.Empty;
                //    if (_playerBL.getPlayerNamebyID(player_id, out name))
                //    {
                //        return RedirectToAction("Index", "players", new { id = name });
                //    }
                //    else
                //    {
                //        throw new Exception("KSULAX||we can't find the player id you requested");
                //    }
                //}
            }

            //find player by full name
            else
            {
                if (string.Compare(id, id.ToLower()).Equals(0))
                {
                    PlayerBE player = _playerBL.PlayerByName(id);
                    if (null == player)
                    {
                        throw new Exception("KSULAX||we can't find the player you requested");
                    }

                    PlayerBioModel result = new PlayerBioModel();

                    result.PlayerInfo = new PlayerModel(player);

                    result.PlayerStatList = new PlayerGameStatListModel(_gameBL.PlayerGameStats(playerID: player.PlayerID));

                    result.PlayerAwardList = new PlayerAwardModelList(_awardBL.AwardsByPlayerID(player.PlayerID));

                    return View("Player", result);
                }
                else
                {
                    return RedirectToAction("Index", "players", new { id = id.ToLower() });
                }
            }
        }

        public FilePathResult image(int id)
        {
            if (id < 0)
            {
                return null;
            }

            string imagePath = "/content/images/players/" + id + ".png";

            if (!System.IO.File.Exists(Server.MapPath(imagePath)))
            {
                imagePath = "/content/images/teams/kennesaw_state_128.png";
            }

            return new FilePathResult(imagePath, "image/png");
        }
        
        private List<PlayerModel> GetPlayerModelLst(List<PlayerBE> PlayerBeLst)
        {
            var Players = new List<PlayerModel>();

            foreach (var player in PlayerBeLst)
            {
                Players.Add(new PlayerModel(player));
            }

            return Players;
        }
    }
}
