<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.Game.GameScheduleModelList>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server"><%= (Model.SeasonID - 1) + " - " + Model.SeasonID + " Game Schedule" %></asp:Content>
<asp:Content ContentPlaceHolderID="Header" runat="server">
<style type="text/css">.hidden { display:none; }</style>
<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
<script type="text/javascript" src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol">
<div class="boxItem menu">
<div class="boxTitle"><%= Html.ActionLink("Seasons", DateTime.Now.Year.ToString(), null, new { title="Seasons" })%></div>
<div class="boxContent">
<ul>
<li><%= Html.ActionLink("2014 - 2015", "index", "schedule", new { id = "2015" }, new { title = "About" })%></li>
<li><%= Html.ActionLink("2013 - 2014", "index", "schedule", new { id = "2014" }, new { title = "About" })%></li>
<li><%= Html.ActionLink("2012 - 2013", "index", "schedule", new { id = "2013" }, new { title = "About" })%></li>
<li><%= Html.ActionLink("2011 - 2012", "index", "schedule", new { id = "2012" }, new { title = "About" })%></li>
<li><%= Html.ActionLink("2010 - 2011", "index", "schedule", new { id = "2011" }, new { title = "About" })%></li>
<li><%= Html.ActionLink("2009 - 2010", "index", "schedule", new { id = "2010" }, new { title = "About" })%></li>
<li><%= Html.ActionLink("2008 - 2009", "index", "schedule", new { id = "2009" }, new { title = "About" })%></li>
<li><%= Html.ActionLink("2007 - 2008", "index", "schedule", new { id = "2008" }, new { title = "About" })%></li>
<li><%= Html.ActionLink("2006 - 2007", "index", "schedule", new { id = "2007" }, new { title = "About" })%></li>
<li><%= Html.ActionLink("2005 - 2006", "index", "schedule", new { id = "2006" }, new { title = "About" })%></li>
</ul>
</div>
<div class="boxBottom"></div>
</div>
<% Html.RenderPartial("DonationTemplate"); %>
</div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title="Home" })%> > <%= Html.ActionLink("Games", "Index", new { id = string.Empty }, new { title="Games" })%> > <%= Html.ActionLink(Model.SeasonID.ToString(), Model.SeasonID.ToString(), null, new { title = Model.SeasonID.ToString() })%></div>
<h1><%= (Model.SeasonID - 1) + " - " + Model.SeasonID%> Game Schedule</h1>
<% Html.RenderPartial("GameTemplate", Model.GameSchedule); %>
<asp:Image ImageUrl="~/content/images/game_scrimage.png" Height="19" Width="19" ImageAlign="Top" AlternateText="Scrimmage" runat="server"/> Scrimmage
<asp:Image ImageUrl="~/content/images/game_divisional.png" Height="17" Width="17" ImageAlign="Top" AlternateText="Divisional Game" runat="server"/> Divisional Game
<asp:Image ImageUrl="~/content/images/game_playoff.png" Height="17" Width="17" ImageAlign="Top" AlternateText="Playoff Game" runat="server"/> Playoff Game
<br/><br/>
<h2><%= (Model.SeasonID - 1) + " - " + Model.SeasonID%> Game Schedule</h2>
<a href="http://mcla.us/teams/kennesaw_state/<%= Model.SeasonID %>/schedule.html">MCLA</a>
<a href="http://www.laxpower.com/update<%=Model.SeasonID.ToString().Substring(2,2)%>/binmen/XKNSXX.PHP">LaxPower</a>
</div>
</asp:Content>