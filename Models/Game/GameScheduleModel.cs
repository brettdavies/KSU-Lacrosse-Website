using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSULax.Entities;
using KSULax.Models.Photo;

namespace KSULax.Models.Game
{
    public class GameScheduleModelList
    {
        public List<GameScheduleModel> GameSchedule { get; set; }

        public int SeasonID
        {
            get
            {
                return GameSchedule[0].Game.SeasonID;
            }
        }
    }

    public class GameScheduleModel
    {
        public GameScheduleModel(GameModel game, List<PhotographerModel> galleries)
        {
            Game = game;
            PhotographerList = galleries;
        }

        public GameModel Game { get; set; }
        public List<PhotographerModel> PhotographerList { get; set; }

        public bool hasPhotographers
        {
            get
            {
                return (PhotographerList.Count > 0) ? true : false;
            }
        }
    }
}
