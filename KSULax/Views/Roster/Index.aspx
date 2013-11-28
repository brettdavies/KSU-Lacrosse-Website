<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.Roster.RosterModel>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server"><%= (Model.SeasonID - 1) + " - " + Model.SeasonID + " Roster"%></asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol">
<div class="boxItem menu">
<div class="boxTitle"><%= Html.ActionLink("Seasons", Model.SeasonID.ToString(), null, new { title = "Seasons" })%></div>
<div class="boxContent">
<ul>
<li><%= Html.ActionLink("2013 - 2014", "2014", null, new { title = "2013 - 2014" })%></li>
<li><%= Html.ActionLink("2012 - 2013", "2013", null, new { title = "2012 - 2013" })%></li>
<li><%= Html.ActionLink("2011 - 2012", "2012", null, new { title = "2011 - 2012" })%></li>
<li><%= Html.ActionLink("2010 - 2011", "2011", null, new { title = "2010 - 2011" })%></li>
<li><%= Html.ActionLink("2009 - 2010", "2010", null, new { title = "2009 - 2010" })%></li>
<li><%= Html.ActionLink("2008 - 2009", "2009", null, new { title = "2008 - 2009" })%></li>
<li><%= Html.ActionLink("2007 - 2008", "2008", null, new { title = "2007 - 2008" })%></li>
<li><%= Html.ActionLink("2006 - 2007", "2007", null, new { title = "2006 - 2007" })%></li>
<li><%= Html.ActionLink("2005 - 2006", "2006", null, new { title = "2005 - 2006" })%></li>
</ul>
</div>
<div class="boxBottom"></div>
</div>
</div>
<div id="mainCol">
<div class="breadcrumbs">
<%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("Roster", "Index", new { id = string.Empty }, new { title = "Roster" })%> > <%= Html.ActionLink(Model.SeasonID.ToString(), Model.SeasonID.ToString(), null, new { title = Model.SeasonID.ToString() })%></div>
<h1><%= (Model.SeasonID - 1) + " - " + Model.SeasonID + " Roster"%></h1>
<script type="text/javascript" src="http://api.mcla.us/simple/?api_key=994f29431bdc1b09f6e00876d98ef2b6&version=1.2&method=roster_widget&team=kennesaw_state&season=<%= Model.SeasonID %>&width=692"></script>
</div>
</asp:Content>