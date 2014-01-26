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
using KSULax.Helpers;
using KSULax.Models.Data;
using KSULax.Models.Game;

namespace KSULax.Controllers
{
    public class NationalRankingController : Controller
    {
        private KSULaxEntities _entities;
        private DataBL _dataBL;
        private GameBL _gameBL;

        public NationalRankingController()
        {
            _entities = new KSULaxEntities();
            _dataBL = new DataBL(_entities);
            _gameBL = new GameBL(_entities);
        }

        public ActionResult Index()
        {
            return RedirectToAction("national-ranking", "nationalranking", new { id = KSU.maxPlayerSeason });
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetRanking()
        {
            return this.Json(_dataBL.GetRanking(), JsonRequestBehavior.AllowGet);
        }

        [ActionName("national-ranking")]
        public ActionResult nationalRanking(int? id)
        {
            if (!id.HasValue || !(id >= 2009 && id <= KSU.maxPlayerSeason))
            {
                return RedirectToAction("national-ranking", "nationalranking", new { id = KSU.maxPlayerSeason });
            }

            int year = id.Value;

            // Get Dates
            List<double> pollDates = _dataBL.GetRankingDates(year);
            double maxDate = pollDates.Max();

            var cacheService = new CachingService();

            var cacheMaxDate = cacheService.Get<double>("chart" + year + "maxdate");

            if (cacheMaxDate < maxDate)
            {
                createChart(year, maxDate, pollDates);
            }

            NationalRankingModel ranking = new NationalRankingModel(new GameListModel(_gameBL.GamesBySeason(year)), year, cacheService.Get<string>("chart" + year + "imagemap"));

            return View(ranking);
        }

        //[OutputCache(Duration = 3600, VaryByParam = "id")]
        [ActionName("ranking-chart")]
        public FileContentResult rankingChart(int? id)
        {
            if (!id.HasValue || !(id >= 2009 && id <= KSU.maxPlayerSeason))
            {
                return null;
            }

            int year = id.Value;

            // Get Dates
            List<double> pollDates = _dataBL.GetRankingDates(year);
            double maxDate = pollDates.Max();

            var cacheService = new CachingService();

            var cacheMaxDate = cacheService.Get<double>("chart" + year + "maxdate");

            if (cacheMaxDate < maxDate)
            {
                createChart(year, maxDate, pollDates);
            }
            
            return new FileContentResult(cacheService.Get<byte[]>("chart" + year + "array"), "image/png");
        }

        /// <summary>
        /// Creates a chart for the specified season and stores it in the cache
        /// </summary>
        /// <param name="id">season id to draw a chart for</param>
        /// <param name="maxDate">maxDate from in double format (ToOADate)</param>
        /// <param name="pollDates">double format of all the dates that have rankings for the specified season</param>
        private void createChart(int id, double maxDate, List<double> pollDates)
        {
            // Get Rankings
            List<TeamRankingBE> rankingsMCLA = _dataBL.GetRanking(1, id);
            List<TeamRankingBE> rankingsCL = _dataBL.GetRanking(2, id);
            List<TeamRankingBE> rankingsLP = _dataBL.GetRanking(3, id);
            List<TeamRankingBE> rankingsMCLACoaches = _dataBL.GetRanking(4, id);

            var mclaExist = rankingsMCLA.Count > 0 ? 1 : 0;
            var clExist = rankingsCL.Count > 0 ? 1 : 0;
            var lpExist = rankingsLP.Count > 0 ? 1 : 0;
            var mclacoachesExist = rankingsMCLACoaches.Count > 0 ? 1 : 0;
            
            var chart = new Chart();

            chart.RenderType = RenderType.ImageTag;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.Titles.Add(new Title("Kennesaw State Owls " + id + " National Ranking", Docking.Top, new Font("Segoe UI", 14, FontStyle.Bold), Color.FromArgb(254, 188, 7)));
            chart.Width = 650;
            chart.Height = 520;

            // ChartArea
            chart.ChartAreas.Add("Default");
            chart.ChartAreas["Default"].Area3DStyle.Enable3D = false;
            chart.ChartAreas["Default"].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
            chart.ChartAreas["Default"].AxisX.LabelStyle.ForeColor = Color.Black;
            chart.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas["Default"].AxisX.LabelStyle.Format = "MMM dd";
            chart.ChartAreas["Default"].AxisX.MajorGrid.Interval = 1;
            chart.ChartAreas["Default"].AxisX.MajorTickMark.Interval = 1;
            chart.ChartAreas["Default"].AxisY.IsReversed = true;
            chart.ChartAreas["Default"].AxisY.Minimum = 0;
            chart.ChartAreas["Default"].AxisY.Maximum = 25;
            
            // Legend
            chart.Legends.Add("Default");
            chart.Legends["Default"].Docking = Docking.Bottom;
            chart.Legends["Default"].Font = new Font("Segoe UI", 12);
            chart.Legends["Default"].BorderColor = Color.Black;
            chart.Legends["Default"].BorderWidth = 1;
            chart.Legends["Default"].BorderDashStyle = ChartDashStyle.Solid;
            chart.Legends["Default"].ShadowOffset = 4;
            chart.Legends["Default"].Alignment = StringAlignment.Center;

            // LaxPower Series
            if (lpExist.Equals(1))
            {
                chart.Series.Add("LaxPower");
                chart.Series["LaxPower"].ChartType = SeriesChartType.Line;
                chart.Series["LaxPower"].Color = Color.Red;
                chart.Series["LaxPower"].BorderWidth = 5;
                chart.Series["LaxPower"].EmptyPointStyle.BorderWidth = 5;
                chart.Series["LaxPower"].EmptyPointStyle.MarkerStyle = MarkerStyle.Cross;
                chart.Series["LaxPower"]["EmptyPointValue"] = "Average";
                chart.Series["LaxPower"].MarkerImage = @"~/content/images/polls/Laxpower_32.png";
                chart.Series["LaxPower"].MarkerImageTransparentColor = Color.Empty;
                chart.Series["LaxPower"].LegendUrl = rankingsLP[rankingsLP.Count-1].Url;
                chart.Series["LaxPower"].ToolTip = "LaxPower: ##VALY";
                chart.Series["LaxPower"].IsXValueIndexed = true;
            }

            // MCLA Series
            if (mclaExist.Equals(1))
            {
                chart.Series.Add("MCLA");
                chart.Series["MCLA"].ChartType = SeriesChartType.Line;
                chart.Series["MCLA"].Color = Color.FromArgb(111, 162, 138);
                chart.Series["MCLA"].BorderWidth = 5;
                chart.Series["MCLA"].EmptyPointStyle.BorderWidth = 5;
                chart.Series["MCLA"].EmptyPointStyle.MarkerStyle = MarkerStyle.None;
                chart.Series["MCLA"]["EmptyPointValue"] = "Average";
                chart.Series["MCLA"].MarkerImage = @"~/content/images/polls/MCLAmag_32.png";
                chart.Series["MCLA"].MarkerImageTransparentColor = Color.Empty;
                chart.Series["MCLA"].LegendUrl = rankingsMCLA[rankingsMCLA.Count-1].Url;
                chart.Series["MCLA"].ToolTip = "MCLA: ##VALY";
                chart.Series["MCLA"].IsXValueIndexed = true;
            }

            // CollegeLax Series
            if (clExist.Equals(1))
            {
                chart.Series.Add("CollegeLax");
                chart.Series["CollegeLax"].ChartType = SeriesChartType.Line;
                chart.Series["CollegeLax"].Color = Color.FromArgb(167, 152, 109);
                chart.Series["CollegeLax"].BorderWidth = 5;
                chart.Series["CollegeLax"].EmptyPointStyle.BorderWidth = 5;
                chart.Series["CollegeLax"].EmptyPointStyle.MarkerStyle = MarkerStyle.Cross;
                chart.Series["CollegeLax"]["EmptyPointValue"] = "Average";
                chart.Series["CollegeLax"].MarkerImage = @"~/content/images/polls/CollegeLax_32.png";
                chart.Series["CollegeLax"].MarkerImageTransparentColor = Color.Empty;
                chart.Series["CollegeLax"].LegendUrl = rankingsCL[rankingsCL.Count - 1].Url;
                chart.Series["CollegeLax"].ToolTip = "CollegeLax: ##VALY";
                chart.Series["CollegeLax"].IsXValueIndexed = true;
            }

            // MCLA Coaches Series
            if (mclacoachesExist.Equals(1))
            {
                chart.Series.Add("MCLACoaches");
                chart.Series["MCLACoaches"].ChartType = SeriesChartType.Line;
                chart.Series["MCLACoaches"].Color = Color.FromArgb(167, 152, 109);
                chart.Series["MCLACoaches"].BorderWidth = 5;
                chart.Series["MCLACoaches"].EmptyPointStyle.BorderWidth = 5;
                chart.Series["MCLACoaches"].EmptyPointStyle.MarkerStyle = MarkerStyle.Cross;
                chart.Series["MCLACoaches"]["EmptyPointValue"] = "Average";
                chart.Series["MCLACoaches"].MarkerImage = @"~/content/images/polls/MCLACoaches_32.png";
                chart.Series["MCLACoaches"].MarkerImageTransparentColor = Color.Empty;
                chart.Series["MCLACoaches"].LegendUrl = rankingsMCLACoaches[rankingsMCLACoaches.Count - 1].Url;
                chart.Series["MCLACoaches"].ToolTip = "MCLA Coaches: ##VALY";
                chart.Series["MCLACoaches"].IsXValueIndexed = true;
            }

            // Populate All Data Points
            if (mclaExist.Equals(1)) { chart.Series["MCLA"].Points.DataBindXY(rankingsMCLA, "Date", rankingsMCLA, "Rank"); }
            if (clExist.Equals(1)) { chart.Series["CollegeLax"].Points.DataBindXY(rankingsCL, "Date", rankingsCL, "Rank"); }
            if (lpExist.Equals(1)) { chart.Series["LaxPower"].Points.DataBindXY(rankingsLP, "Date", rankingsLP, "Rank"); }
            if (mclacoachesExist.Equals(1)) { chart.Series["MCLACoaches"].Points.DataBindXY(rankingsMCLACoaches, "Date", rankingsMCLACoaches, "Rank"); }

            int i = 0;
            if (lpExist.Equals(1))
            {
                foreach (DataPoint dp in chart.Series["LaxPower"].Points)
                {
                    dp.Url = rankingsLP[i].Url;
                    i++;
                }
            }
            
            if (clExist.Equals(1))
            {
                i = 0;
                foreach (DataPoint dp in chart.Series["CollegeLax"].Points)
                {
                    dp.Url = rankingsCL[i].Url;
                    i++;
                }
            }

            if (mclaExist.Equals(1))
            {
                i = 0;
                foreach (DataPoint dp in chart.Series["MCLA"].Points)
                {
                    dp.Url = rankingsMCLA[i].Url;
                    i++;
                }
            }

            if (mclacoachesExist.Equals(1))
            {
                i = 0;
                foreach (DataPoint dp in chart.Series["MCLACoaches"].Points)
                {
                    dp.Url = rankingsMCLACoaches[i].Url;
                    i++;
                }
            }

            // Fill remaining data points with empty values
            // allows for .IsXValueIndexed = true on the series.
            foreach (double pollDate in pollDates)
            {
                var data = (int)1;
                if (mclaExist.Equals(1))
                {
                    data = chart.Series["MCLA"].Points.Count(dp => dp.XValue == pollDate);
                    if (data == 0)
                    {
                        chart.Series["MCLA"].Points.Add(new DataPoint { XValue = pollDate, YValues = new double[1] { 0 }, IsEmpty = true });
                    }
                }

                if (clExist.Equals(1))
                {
                    data = chart.Series["CollegeLax"].Points.Count(dp => dp.XValue == pollDate);
                    if (data == 0)
                    {
                        chart.Series["CollegeLax"].Points.Add(new DataPoint { XValue = pollDate, YValues = new double[1] { 0 }, IsEmpty = true });
                    }
                }

                if (lpExist.Equals(1))
                {
                    data = chart.Series["LaxPower"].Points.Count(dp => dp.XValue == pollDate);
                    if (data == 0)
                    {
                        chart.Series["LaxPower"].Points.Add(new DataPoint { XValue = pollDate, YValues = new double[1] { 0 }, IsEmpty = true });
                    }
                }

                if (mclacoachesExist.Equals(1))
                {
                    data = chart.Series["MCLACoaches"].Points.Count(dp => dp.XValue == pollDate);
                    if (data == 0)
                    {
                        chart.Series["MCLACoaches"].Points.Add(new DataPoint { XValue = pollDate, YValues = new double[1] { 0 }, IsEmpty = true });
                    }
                }
            }

            // Sort data points by X value
            // allows for .IsXValueIndexed = true on the series.
            if (mclaExist.Equals(1))
            {
                chart.DataManipulator.Sort(PointSortOrder.Ascending, "X", "MCLA");
            }
            if (clExist.Equals(1))
            {
                chart.DataManipulator.Sort(PointSortOrder.Ascending, "X", "CollegeLax");
            }
            if (lpExist.Equals(1))
            {
                chart.DataManipulator.Sort(PointSortOrder.Ascending, "X", "LaxPower");
            }
            if (mclacoachesExist.Equals(1))
            {
                chart.DataManipulator.Sort(PointSortOrder.Ascending, "X", "MCLACoaches");
            }

            var imageStream = new MemoryStream();

            chart.SaveImage(imageStream, ChartImageFormat.Png);

            string imagemap = chart.GetHtmlImageMap("ranking");

            var cacheService = new CachingService();

            cacheService.Insert("chart" + id + "maxdate", maxDate);
            cacheService.Insert("chart" + id + "array", imageStream.ToArray());
            cacheService.Insert("chart" + id + "imagemap", imagemap);
        }
    }
}
