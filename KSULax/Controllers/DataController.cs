using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSULax.Models;
using KSULax.Logic;
using KSULax.Entities;
using KSULax.Dal;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

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

        [ActionName("ranking-chart")]
        public FileContentResult rankingChart(int id)
        {
            if (!(id >= 2009 && id <= KSU.maxPlayerSeason))
            {
                return null;
            }

            // Get Data
            List<TeamRankingBE> rankingsMCLA = _dataBL.GetRanking(1, id);
            List<TeamRankingBE> rankingsCL = _dataBL.GetRanking(2, id);
            List<TeamRankingBE> rankingsLP = _dataBL.GetRanking(3, id);
            double minDate = new DateTime(id, 1, 1).ToOADate();
            double maxDate = new DateTime(id, 12, 31).ToOADate();

            var chart = new Chart();

            chart.RenderType = RenderType.BinaryStreaming;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.Palette = ChartColorPalette.BrightPastel;
            chart.Titles.Add(new Title(id + " Ranking", Docking.Top, new Font("Segoe UI", 14, FontStyle.Bold), Color.DarkRed));
            chart.Width = 500;
            chart.Height = 400;

            // ChartArea
            chart.ChartAreas.Add("Default");
            chart.ChartAreas["Default"].Area3DStyle.Enable3D = false;
            chart.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas["Default"].AxisX.MajorGrid.Interval = 1;
            chart.ChartAreas["Default"].AxisX.MajorTickMark.Interval = 1;
            chart.ChartAreas["Default"].AxisY.IsReversed = true;
            chart.ChartAreas["Default"].AxisY.Minimum = 0;
            chart.ChartAreas["Default"].AxisY.Maximum = 25;

            // Legend
            chart.Legends.Add("Default");
            chart.Legends["Default"].Docking = Docking.Bottom;
            chart.Legends["Default"].BorderColor = Color.Black;
            chart.Legends["Default"].BorderWidth = 1;
            chart.Legends["Default"].BorderDashStyle = ChartDashStyle.Solid;
            chart.Legends["Default"].ShadowOffset = 4;
            chart.Legends["Default"].Alignment = StringAlignment.Center;

            chart.Series.Add("MCLA");
            chart.Series["MCLA"].ChartType = SeriesChartType.Line;
            chart.Series["MCLA"].Points.DataBindXY(rankingsMCLA, "Date", rankingsMCLA, "Rank");

            //double curDate = minDate;
            //while (curDate <= maxDate)
            //{
            //    var data = chart.Series["MCLA"].Points.Count(dp => dp.XValue == curDate);
            //    if (data == 0)
            //    {
            //        chart.Series["MCLA"].Points.Add(new DataPoint { XValue = curDate, YValues = new double[1] { 0 }, IsEmpty = true });
            //    }
            //    curDate++;
            //}

            chart.Series["MCLA"].EmptyPointStyle.BorderWidth = 0;
            chart.Series["MCLA"].EmptyPointStyle.MarkerStyle = MarkerStyle.None;
            chart.Series["MCLA"].MarkerImage = @"~/content/images/polls/MCLAmag.png";
            chart.Series["MCLA"].MarkerImageTransparentColor = Color.White;
            chart.Series["MCLA"].Url = rankingsMCLA[0].Url;
            chart.Series["MCLA"].LegendUrl = rankingsMCLA[0].Url;
            chart.Series["MCLA"].ToolTip = "#VALY";
            chart.Series["MCLA"].IsXValueIndexed = true;

            //chart.Series.Add("CollegeLax");
            //chart.Series["CollegeLax"].ChartType = SeriesChartType.Line;
            //chart.Series["CollegeLax"].Points.DataBindXY(rankingsCL, "Date", rankingsCL, "Rank");

            //curDate = minDate;
            //while (curDate <= maxDate)
            //{
            //    var data = chart.Series["CollegeLax"].Points.Count(dp => dp.XValue == curDate);
            //    if (data == 0)
            //    {
            //        chart.Series["CollegeLax"].Points.Add(new DataPoint { XValue = curDate, YValues = new double[1] { 0 }, IsEmpty = true });
            //    }
            //    curDate++;
            //}

            //chart.Series["CollegeLax"].EmptyPointStyle.BorderWidth = 0;
            //chart.Series["CollegeLax"].EmptyPointStyle.MarkerStyle = MarkerStyle.None;
            //chart.Series["CollegeLax"].MarkerImage = @"~/content/images/polls/CollegeLax.png";
            //chart.Series["CollegeLax"].MarkerImageTransparentColor = Color.White;
            //chart.Series["CollegeLax"].Url = rankingsCL[0].Url;
            //chart.Series["CollegeLax"].LegendUrl = rankingsCL[0].Url;
            //chart.Series["CollegeLax"].ToolTip = "#VALY";
            //chart.Series["CollegeLax"].IsXValueIndexed = true;

            //chart.Series.Add("LaxPower");
            //chart.Series["LaxPower"].ChartType = SeriesChartType.Line;
            //chart.Series["LaxPower"].Points.DataBindXY(rankingsLP, "Date", rankingsLP, "Rank");

            //curDate = minDate;
            //while (curDate <= maxDate)
            //{
            //    var data = chart.Series["CollegeLax"].Points.Count(dp => dp.XValue == curDate);
            //    if (data == 0)
            //    {
            //        chart.Series["CollegeLax"].Points.Add(new DataPoint { XValue = curDate, YValues = new double[1] { 0 }, IsEmpty = true });
            //    }
            //    curDate++;
            //}

            //chart.Series["LaxPower"].EmptyPointStyle.BorderWidth = 0;
            //chart.Series["LaxPower"].EmptyPointStyle.MarkerStyle = MarkerStyle.None;
            //chart.Series["LaxPower"].MarkerImage = @"~/content/images/polls/Laxpower.png";
            //chart.Series["LaxPower"].MarkerImageTransparentColor = Color.White;
            //chart.Series["LaxPower"].Url = rankingsLP[0].Url;
            //chart.Series["LaxPower"].LegendUrl = rankingsLP[0].Url;
            //chart.Series["LaxPower"].ToolTip = "#VALY";
            //chart.Series["LaxPower"].IsXValueIndexed = true;

            var imageStream = new MemoryStream();
            chart.SaveImage(imageStream, ChartImageFormat.Png);

            string imagemap = chart.GetHtmlImageMap("ranking");

            return new FileContentResult(imageStream.ToArray(), "image/png");
        }
    }
}
