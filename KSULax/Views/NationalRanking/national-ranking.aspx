<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.Data.NationalRankingModel>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server">National Ranking</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol"><% Html.RenderPartial("GameSidebarTemplate", Model.Games); %></div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("National Ranking", "index", "national-ranking", null, new { title = "National Ranking" })%> > <%= Html.ActionLink(Model.Year.ToString(), null, null, new { id = Model.Year }, new { title = Model.Year.ToString() + " National Ranking" })%></div>
<h1><%= Model.Year %> National Ranking</h1>
<%= Model.ChartMap %>
<img class="imgBioBorder" src="<%= Url.Content(Model.ChartPath) %>" usemap="#ranking" alt="Kennesaw State Owls <%= Model.Year %> National Rankings" title="Kennesaw State Owls <%= Model.Year %> National Rankings" align="left" />

<h2>CollegeLax.us Prodigy MCLA Polls Top 25</h2>
<h3>Poll Methodology and Process</h3>
<p>The Prodigy MCLA Top 25 Poll is comprised of current MCLA coaches and MCLA conference administrators who have committed to submit rankings for the top 25 MCLA teams each week. These panelists were selected by CollegeLAX from multiple nominations submitted by various MCLA coaches and all 10 MCLA conferences. The panel has been designed to be a statistically valid representation of all MCLA conferences and includes numerous coaches from across the country.</p>
<p>The Prodigy Top 25 poll will be the only ranking system considered by members of the 2011 MCLA National Tournament Selection Committee. A full list of all Prodigy MCLA poll rankings throughout the season can be found at <a href="http://www.collegelax.us/polls.php">http://www.collegelax.us/polls.php</a>.</p>

<br />

<h2>LaxPower</h2>
<h3>Power Ratings Explanation</h3>
<p>The computer power rating for college lacrosse is based on margin of victory calculations, including a 10-goal limit constraint. In addition, predictions are made for the selection of teams to the men MCLA championship tournament for Divisions I and II, which is predicated on strength of schedule, ratings percentage index, quality wins, win-loss records, and polls. More information about the criteria can be found at <a href="http://www.laxpower.com/update11/ex_col.php">http://www.laxpower.com/update11/ex_col.php</a>.</p>
</div>
</asp:Content>