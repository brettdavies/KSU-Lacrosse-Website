using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using KSULax.Models.Game;

namespace KSULax.Models.Data
{
    public class NationalRankingModel
    {
        public NationalRankingModel()
        {
            Games = null;
            Year = int.MinValue;
            ChartPath = string.Empty;
            ChartMap = string.Empty;
        }

        public NationalRankingModel(GameListModel GameList, int year, string chartmap)
        {
            Games = GameList;
            Year = year;
            ChartPath = "/national-ranking/ranking-chart/" + year;
            ChartMap = chartmap;
        }

        public GameListModel Games { get; set; }
        public int Year { get; set; }
        public string ChartPath { get; set; }
        public string ChartMap { get; set; }
    }
}
