using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;
using KSULax.Models;
using KSULax.Controllers;
using System.Data.Objects.DataClasses;

namespace KSULax.Logic
{
    public class PlayerBL
    {
        KSULaxEntities _entities;

        public PlayerBL(KSULaxEntities entitity) { _entities = entitity; }

        public bool getPlayerNamebyID(short player_id, out string name)
        {
            List<PlayerEntity> result = _entities.PlayerSet
                      .Where("it.id = " + player_id)
                      .Take(1)
                      .ToList();

            if (result.Count() > 0)
            {
                name = (result.ElementAt<PlayerEntity>(0).first + "-" + result.ElementAt<PlayerEntity>(0).last).ToLower();
                return true;
            }
            else
            {
                name = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Returns a list of PlayerSeason objects for a certain season
        /// </summary>
        /// <param name="seasonID">Season ID to find players for.</param>
        /// <returns></returns>
        public List<PlayerSeasonBE> PlayersBySeason(int seasonID)
        {
            var playerseason = new List<PlayerSeasonEntity>(_entities.PlayerSeasonSet
                      .Include("Player")
                      .Where("it.season_id = " + seasonID)
                      .OrderBy("it.jersey")
                      .ToList());

            var result = new List<PlayerSeasonBE>();

            foreach (PlayerSeasonEntity pse in playerseason)
            {
                result.Add(GetEntity(pse));
            }
            return result;
        }

        public bool PlayerByName(string name, out PlayerBE result)
        {
            string first = string.Empty;
            string last = string.Empty;

            try
            {
                first = name.Substring(0, name.IndexOf("-"));
                last = name.Substring(name.IndexOf("-") + 1);

                var player = _entities.PlayerSet
                                .Include("PlayerGame")
                                .Include("PlayerSeason")
                                .Include("PlayerAward")
                                .Include("PlayerAward.Award")
                                .Where("it.first like ('" + first + "')")
                                .Where("it.last like ('" + last + "')")
                                .Take<PlayerEntity>(1)
                                .FirstOrDefault<PlayerEntity>();

                if (null != player)
                {
                    result = GetEntity(player);
                    return true;
                }
                else
                {
                    result = null;
                    return false;
                }
            }

            catch (Exception)
            {
                throw new Exception("KSULAX||we can't find the player you requested");
            }
        }

        private PlayerBE GetEntity(PlayerEntity pe)
        {
            if (null == pe)
            {
                return null;
            }

            var result = new PlayerBE
            {
                PlayerAward = GetEntity(pe.PlayerAward),
                Bio = pe.bio,
                FirstName = pe.first,
                PlayerGame = GetEntity(pe.PlayerGame),
                HighSchool = pe.highschool,
                HomeState = pe.homestate,
                Hometown = pe.hometown,
                LastName = pe.last,
                Major = pe.major,
                MiddleName = pe.middle,
                PlayerID = pe.id,
                PlayerSeason = GetEntity(pe.PlayerSeason)
            };
            return result;
        }

        private PlayerSeasonBE GetEntity(PlayerSeasonEntity pse)
        {
            if (null == pse)
            {
                return null;
            }

            var result = new PlayerSeasonBE
            {
                Captain = pse.captain.GetValueOrDefault(),
                ClassYr = pse.@class,
                EligibilityYr = pse.eligibility,
                Height = pse.height.GetValueOrDefault(),
                JerseyNum = pse.jersey.GetValueOrDefault(),
                Officer = pse.officer.GetValueOrDefault(),
                Player = GetEntity(pse.Player),
                PlayerID = pse.player_id,
                Position = pse.position,
                President = pse.president.GetValueOrDefault(),
                SeasonID = pse.season_id,
                Weight = pse.weight.GetValueOrDefault()
            };
            return result;
        }

        private PlayerGameBE GetEntity(PlayerGameEntity pge)
        {
            if (null == pge)
            {
                return null;
            }

            var result = new PlayerGameBE
            {
                Assists = pge.assists,
                GameID = pge.game_id,
                Goals = pge.goals,
                GoalsAgainst = pge.ga,
                Player = GetEntity(pge.Player),
                PlayerID = pge.player_id,
                Saves = pge.saves
            };
            return result;
        }

        private PlayerAwardBE GetEntity(PlayerAwardEntity pae)
        {
            if (null == pae)
            {
                return null;
            }

            var result = new PlayerAwardBE
            {
                Award = GetEntity(pae.Award),
                AwardID = pae.award_id,
                Date = pae.date,
                Player = GetEntity(pae.Player),
                PlayerID = pae.player_id
            };
            return result;
        }

        private AwardBE GetEntity(AwardEntity ae)
        {
            if (null == ae)
            {
                return null;
            }

            var result = new AwardBE
            {
                AwardID = ae.id,
                Name = ae.name,
                PlayerAward = GetEntity(ae.PlayerAward)
            };
            return result;
        }

        private List<PlayerSeasonBE> GetEntity(EntityCollection<PlayerSeasonEntity> pseColl)
        {
            if (null == pseColl)
            {
                return null;
            }

            var result = new List<PlayerSeasonBE>();

            foreach (PlayerSeasonEntity pse in pseColl)
            {
                result.Add(GetEntity(pse));
            }

            return result;
        }

        private List<PlayerGameBE> GetEntity(EntityCollection<PlayerGameEntity> pgeColl)
        {
            if (null == pgeColl)
            {
                return null;
            }

            var result = new List<PlayerGameBE>();

            foreach (PlayerGameEntity pge in pgeColl)
            {
                result.Add(GetEntity(pge));
            }

            return result;
        }

        private List<PlayerAwardBE> GetEntity(EntityCollection<PlayerAwardEntity> paeColl)
        {
            if (null == paeColl)
            {
                return null;
            }

            var result = new List<PlayerAwardBE>();

            foreach (PlayerAwardEntity pae in paeColl)
            {
                result.Add(GetEntity(pae));
            }

            return result;
        }
    }
}